﻿using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using VirtoCommerce.Foundation.Security.Model;
using VirtoCommerce.ManagementClient.Core.Infrastructure;
using VirtoCommerce.ManagementClient.Core.Infrastructure.Navigation;
using VirtoCommerce.ManagementClient.Security.ViewModel.Implementations;
using VirtoCommerce.ManagementClient.Security.ViewModel.Interfaces;
using VirtoCommerce.Foundation.Data.Security;
using VirtoCommerce.Foundation.Security.Factories;
using VirtoCommerce.Foundation.Security.Repositories;
using VirtoCommerce.Foundation.Security.Services;
using VirtoCommerce.ManagementClient.Security.Tokens;
using VirtoCommerce.ManagementClient.Security.ViewModel.Wizard.Implementations;
using VirtoCommerce.ManagementClient.Security.ViewModel.Wizard.Interfaces;

namespace VirtoCommerce.ManagementClient.Security
{
    public class SecurityModule : IModule
    {
        // test users / roles
        internal const string UserNameAdmin = "admin";
        internal const string UserNameOrderManager = "Everyone";

        private readonly IUnityContainer _container;
        private readonly NavigationManager _navigationManager;

        public SecurityModule(IUnityContainer container, NavigationManager navigationmanager)
        {
            _container = container;
            _navigationManager = navigationmanager;
        }
        #region IModule Members

        public void Initialize()
        {
            RegisterLoginViewsAndServices();
            //Register home view
            var loginViewModel = _container.Resolve<ILoginViewModel>();
            var loginNavItem = new NavigationItem(NavigationNames.LoginName, loginViewModel);

            loginViewModel.LogonViewRequestedEvent += (sender, args) =>
            {
                BackgroundWorker _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.DoWork += (sender1, args1) =>
                    {
                        try
                        {
                            InitializeUsersModule();
                            InitializeModules();
                            InitializeMainModule(); //should be last
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, (Action)delegate
                            {
                                _navigationManager.ShowNavigationMenu();
                                _navigationManager.NavigateToDefaultPage();
                                _navigationManager.UnRegisterNavigationItem(loginNavItem);
                            });
                        }
                        catch (Exception e)
                        {
                            Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, (Action)delegate
                                {
                                    throw e;
                                });
                        }
                    };

                _backgroundWorker.RunWorkerAsync();
            };

            _navigationManager.RegisterNavigationItem(loginNavItem);
            _navigationManager.Navigate(loginNavItem);
        }

        #endregion

        private void InitializeUsersModule()
        {
            var authContext = _container.Resolve<IAuthenticationContext>();
            RegisterViewsAndServices();
            if (authContext.CheckPermission(PredefinedPermissions.SecurityAccounts) || authContext.CheckPermission(PredefinedPermissions.SecurityRoles))
            {
                //Register menu item
                IViewModel homeViewModel = _container.Resolve<ISecurityMainViewModel>();
                var homeNavItem = new NavigationItem(NavigationNames.HomeName, homeViewModel);

                _navigationManager.RegisterNavigationItem(homeNavItem);

                var menuNavItem = new NavigationMenuItem(NavigationNames.MenuName);
                menuNavItem.NavigateCommand =
                    new DelegateCommand<NavigationItem>((x) => { _navigationManager.Navigate(homeNavItem); });
                menuNavItem.Caption = "Users";
                menuNavItem.ImageResourceKey = "Icon_Module_Security";
                menuNavItem.ItemBackground = Color.FromRgb(64, 159, 216);
                menuNavItem.Order = 101;
                _navigationManager.RegisterNavigationItem(menuNavItem);
            }


        }

        private void InitializeModules()
        {
            var moduleManager = _container.Resolve<IModuleManager>();


            moduleManager.LoadModule("ConfigurationModule");
            moduleManager.LoadModule("AppConfigModule");
            moduleManager.LoadModule("AssetModule"); // AssetModule is loaded on demand as a dependency

            moduleManager.LoadModule("OrderModule"); 
            moduleManager.LoadModule("MarketingModule");
            moduleManager.LoadModule("CatalogModule");
            moduleManager.LoadModule("FulfillmentModule");
            moduleManager.LoadModule("CustomersModule");

            moduleManager.LoadModule("ReportingModule");

        }

        private void InitializeMainModule()
        {
            var moduleManager = _container.Resolve<IModuleManager>();
            moduleManager.LoadModule("MainModule");
        }

        private void RegisterLoginViewsAndServices()
        {
            _container.RegisterType<ISecurityEntityFactory, SecurityEntityFactory>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ISecurityRepository, DSSecurityClient>();
            _container.RegisterType<ISecurityTokenInjector, SecurityTokenInjector>();

            _container.RegisterType<LoginViewModel>(new ContainerControlledLifetimeManager());
            _container.RegisterType<ILoginViewModel, LoginViewModel>();
            var resources = new ResourceDictionary
            {
                Source = new Uri("/VirtoCommerce.ManagementClient.Security;component/SecurityModuleDictionary.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(resources);
        }

        protected void RegisterViewsAndServices()
        {
			//_container.RegisterType<IServiceConnectionFactory, ServiceConnectionFactory>();
			//Service registration moved to LoginViewModel as connection string base url passed via login view.
			//_container.RegisterService<ISecurityService>(
			//	_container.Resolve<IServiceConnectionFactory>().GetConnectionString(SecurityConfiguration.Instance.Connection.ServiceUri),
			//	"SecurityServiceConnectionEndPoint");
#if USE_MOCK
            _container.RegisterType<IAuthenticationService, MockAuthenticationService>(new ContainerControlledLifetimeManager());
#else
			//Service registration moved to LoginViewModel as connection string base url passed via login view.
            //_container.RegisterService<IAuthenticationService>(
            //    _container.Resolve<IServiceConnectionFactory>().GetConnectionString(SecurityConfiguration.Instance.Authentication.ServiceUri),
            //    SecurityConfiguration.Instance.Authentication.WSEndPointName);
#endif
            // context created when user logs in, inside LoginViewModel
            // _container.RegisterType<IAuthenticationContext, AuthenticationContext>(new ContainerControlledLifetimeManager());
			
            _container.RegisterType<ISecurityMainViewModel, SecurityMainViewModel>();
            _container.RegisterType<IAccountHomeViewModel, AccountHomeViewModel>();
            _container.RegisterType<IAccountViewModel, AccountViewModel>();
            _container.RegisterType<IPasswordChangeViewModel, PasswordChangeViewModel>();            
            _container.RegisterType<IRoleHomeViewModel, RoleHomeViewModel>();
            _container.RegisterType<IRoleViewModel, RoleViewModel>();

            //Create Account Wizard
            _container.RegisterType<ICreateAccountViewModel, CreateAccountViewModel>();
            _container.RegisterType<IAccountOverviewStepViewModel, AccountOverviewStepViewModel>();
            _container.RegisterType<IAccountRolesStepViewModel, AccountRolesStepViewModel>();

            //Create Role Wizard
            _container.RegisterType<ICreateRoleViewModel, CreateRoleViewModel>();
            _container.RegisterType<IRoleOverviewStepViewModel, RoleOverviewStepViewModel>();

        }
    }
}

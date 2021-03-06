﻿using System;
using VirtoCommerce.ManagementClient.Core.Controls;
using VirtoCommerce.ManagementClient.Core.Infrastructure;
using VirtoCommerce.Foundation.Frameworks;
using VirtoCommerce.Foundation.Marketing.Model;

namespace VirtoCommerce.ManagementClient.Marketing.Model
{
    [Serializable]
	public class CatalogPromotionExpressionBlock : PromotionExpressionBlock
    {
        private ConditionAndOrBlock _conditionBlock;
        public ConditionAndOrBlock ConditionBlock
        {
            get
            {
                return _conditionBlock;
            }
            private set
            {
                _conditionBlock = value;
                Children.Add(_conditionBlock);
            }
        }

        private ActionBlock _actionBlock;
        public ActionBlock ActionBlock
        {
            get
            {
                return _actionBlock;
            }
            private set
            {
                _actionBlock = value;
                Children.Add(_actionBlock);
            }
        }

		public CatalogPromotionExpressionBlock(IExpressionViewModel promotionViewModel)
            : base(null, promotionViewModel)
        {
            ConditionBlock = new ConditionAndOrBlock("if", promotionViewModel, "of these conditions are true");
            ActionBlock = new ActionBlock("They get:", promotionViewModel);
            InitializeAvailableExpressions();
        }

        private void InitializeAvailableExpressions()
        {
			var availableElements = new Func<CompositeElement>[] { 
				()=> new ConditionCategoryIs(ExpressionViewModel),
				()=> new ConditionEntryIs(ExpressionViewModel),
				()=> new ConditionCurrencyIs(ExpressionViewModel)
			};
			ConditionBlock.WithAvailabeChildren(availableElements);
			ConditionBlock.NewChildLabel = "+ add condition";
			ConditionBlock.IsChildrenRequired = true;
			ConditionBlock.ErrorMessage = "Promotion requires at least one condition";

			availableElements = new Func<CompositeElement>[] {
				()=> new ActionCatalogItemGetOfAbs(ExpressionViewModel),
				()=> new ActionCatalogItemGetOfRel(ExpressionViewModel)
				, ()=> new ActionCatalogItemGiftNumItemOfSku(ExpressionViewModel)
			};
			ActionBlock.WithAvailabeChildren(availableElements);
			ActionBlock.NewChildLabel = "+ add effect";
			ActionBlock.IsChildrenRequired = true;
			ActionBlock.ErrorMessage = "Promotion requires at least one reward";
        }

		public override PromotionReward[] GetPromotionRewards()
        {
            return ActionBlock.GetPromotionRewards();
        }

		public override System.Linq.Expressions.Expression<Func<IEvaluationContext, bool>> GetExpression()
		{
			var retVal = ConditionBlock.GetExpression();
			return retVal;
		}

		public override void InitializeAfterDeserialized(IExpressionViewModel promotionViewModel)
        {
            base.InitializeAfterDeserialized(promotionViewModel);
            InitializeAvailableExpressions();

        }
		
	}
}

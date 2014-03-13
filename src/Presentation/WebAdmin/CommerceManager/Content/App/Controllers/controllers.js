'use strict';

/* Controllers */

var vcControllers = angular.module('vcApp.controllers', ['ngGrid', 'treeControl']);

vcControllers.controller('HomeController', 
  function ($scope, $timeout, shell, notificationFactory) {
      $scope.items = {};    
      $scope.gridOptions = { data: 'items' };
      
      $scope.getItems = function() {
          $scope.items = shell.getDataSet();
      };
      
      $scope.init = function () {
          var success = function (data) {
              $scope.items = data.data;
          };

          var failure = function (data) {
              notificationFactory.error(data);
          };

          shell.getDataSet('catalog/items', success, failure);
      };

      $scope.treeOptions = {
          nodeChildren: "children",
          dirSelectable: true,
          injectClasses: {
              ul: "a1",
              li: "a2",
              liSelected: "a7",
              iExpanded: "a3",
              iCollapsed: "a4",
              iLeaf: "a5",
              label: "a6",
              labelSelected: "a8"
          }
      };
      
      $scope.dataForTheTree =
      [
          {
              "name": "Apple", "type": "catalog", "children": [
                { "name": "Audio & MP3", "type": "category", "children": [] },
                {
                    "name": "TVs", "type": "category", "children": [
                      {
                          "name": "HDTV", "type": "category", "children": [
                            { "name": "Plasma", "type": "category", "children": [] },
                            { "name": "LED", "type": "category", "children": [] }
                          ]
                      }
                    ]
                }
              ]
          },
          { "name": "Sony", "type": "catalog", "children": [] },
          { "name": "Samsung", "type": "catalog", "children": [] }
      ];

      $scope.init();
  });


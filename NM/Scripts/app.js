var ProductsApp = angular.module('ProductsApp', ['ui.bootstrap']);

function loadImageToBase64DataURL() {
    var filesSelected = document.getElementById("inputFileToLoad").files;
    if (filesSelected.length > 0) {
        var fileToLoad = filesSelected[0];

        var fileReader = new FileReader();

        fileReader.onload = function (fileLoadedEvent) {
            ProductsApp.imageData = fileLoadedEvent.target.result;
            $('#productImage').attr('src', ProductsApp.imageData);
        };

        fileReader.readAsDataURL(fileToLoad);
    }
}

ProductsApp.controller('ProductsController', function ($scope, $http) {
    $scope.currentPage = 1;
    $scope.itemsPerPage = 50;

    $scope.GetProducts = function () {
        $http.post('/Home/GetProducts', { currentPage: $scope.currentPage, itemsPerPage: $scope.itemsPerPage, searchFragment: $scope.searchFragment }).then(function (response) {
            $scope.products = response.data.products;
            $scope.totalItems = response.data.totalItems;
        });
    }
    $scope.GetProducts();

    $scope.pageChanged = function () {
        $scope.GetProducts();
    };

    //admin
    $scope.OpenImageUpload = function () {
        $('#inputFileToLoad').click();        
    }

    $scope.EditProduct = function (product) {
        $scope.Id = product.Id;
        $scope.Description = product.Description;
        $scope.Amount = product.Amount;
        ProductsApp.imageData = product.Image;
        $('#productImage').attr('src', product.Image);
    }

    $scope.ResetForm = function () {
        $scope.Description = '';
        $scope.Amount = '';
        ProductsApp.imageData = '';
        $('#productImage').attr('src', '');
    }

    $scope.SaveProduct = function (productToSave) {
        var product = productToSave === undefined ? {
            Id: $scope.Id,
            Description: $scope.Description,
            Amount: $scope.Amount,
            Image: ProductsApp.imageData
        } : productToSave;

        $http.post('/Home/SaveProduct', { product: product }).then(function (response) {
            if (response.data.saveResult) {
                $scope.ResetForm();
                $scope.GetProducts();
            }
            else {
                alert('მონაცემი ვერ შეინახა!');
            }
        });
    }

    $scope.DeleteProduct = function (product) {
        product.Deleted = true;
        $scope.SaveProduct(product);
    }
    //---
});
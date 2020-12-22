
// For Checkbox

var app = angular.module('myApp', [])
app.controller('MyController', function ($scope, $window) {
    $scope.Hobbies = [{
        hobbyid: 1,
        Name: 'Cricket',
        Selected: false
    }, {
        hobbyid: 2,
        Name: 'Songs',
        Selected: false
    }, {
        hobbyid: 3,
        Name: 'Chess',
        Selected: false
    }];

    $scope.GetValue = function () {
        var message = "";
        for (var i = 0; i < $scope.Hobbies.length; i++) {
            if ($scope.Hobbies[i].Selected) {
                var fruitId = $scope.Hobbies[i].hobbyid;
                var fruitName = $scope.Hobbies[i].Name;
                message += "Value: " + fruitId + " Text: " + fruitName + "\n";
                $window.alert(message);
            }
        }
    }
});
// For insert get update delete
var app = angular.module("Crud", []);  
app.controller("CRUDCONTROL", function($scope, $http) {  
    debugger;  
    $scope.InsertData = function() {  
        var Action = document.getElementById("btnSave").getAttribute("value");  
        if (Action == "Submit") {  
            $scope.Employe = {};  
            $scope.Employe.Emp_Name = $scope.EmpName;  
            $scope.Employe.Emp_City = $scope.EmpCity;  
            $scope.Employe.Emp_Age = $scope.EmpAge;  
            $http({  
                method: "post",  
                url: "http://localhost:39209/Employee/Insert_Employee",  
                datatype: "json",  
                data: JSON.stringify($scope.Employe)  
            }).then(function(response) {  
                alert(response.data);  
                $scope.GetAllData();  
                $scope.EmpName = "";  
                $scope.EmpCity = "";  
                $scope.EmpAge = "";  
            })  
        } else {  
            $scope.Employe = {};  
            $scope.Employe.Emp_Name = $scope.EmpName;  
            $scope.Employe.Emp_City = $scope.EmpCity;  
            $scope.Employe.Emp_Age = $scope.EmpAge;  
            $scope.Employe.Emp_Id = document.getElementById("EmpID_").value;  
            $http({  
                method: "post",  
                url: "http://localhost:39209/Employee/Update_Employee",  
                datatype: "json",  
                data: JSON.stringify($scope.Employe)  
            }).then(function(response) {  
                alert(response.data);  
                $scope.GetAllData();  
                $scope.EmpName = "";  
                $scope.EmpCity = "";  
                $scope.EmpAge = "";  
                document.getElementById("btnSave").setAttribute("value", "Submit");  
                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";  
                document.getElementById("spn").innerHTML = "Add New Employee";  
            })  
        }  
    }  
    $scope.GetAllData = function() {  
        $http({  
            method: "get",  
            url: "http://localhost:39209/Employee/Get_AllEmployee"  
        }).then(function(response) {  
            $scope.employees = response.data;  
        }, function() {  
            alert("Error Occur");  
        })  
    };  
    $scope.DeleteEmp = function(Emp) {  
        $http({  
            method: "post",  
            url: "http://localhost:39209/Employee/Delete_Employee",  
            datatype: "json",  
            data: JSON.stringify(Emp)  
        }).then(function(response) {  
            alert(response.data);  
            $scope.GetAllData();  
        })  
    };  
    $scope.UpdateEmp = function(Emp) {  
        document.getElementById("EmpID_").value = Emp.Emp_Id;  
        $scope.EmpName = Emp.Emp_Name;  
        $scope.EmpCity = Emp.Emp_City;  
        $scope.EmpAge = Emp.Emp_Age;  
        document.getElementById("btnSave").setAttribute("value", "Update");  
        document.getElementById("btnSave").style.backgroundColor = "Yellow";  
        document.getElementById("spn").innerHTML = "Update Employee Information";  
    }  
})  
Now, provide the references of AngularJS and AngularCode file that we created into Index View.



// For Checkbox

var app = angular.module('myApp', [])
app.controller('MyController', function ($scope, $http) {
    //$scope.Hobbies = [{
    //    HobbieId: '1',
    //    HobbieName: 'Cricket',
    //    checked: false
    //}, {
    //    HobbieId: '2',
    //    HobbieName: 'Songs',
    //    checked: false
    //}, {
    //    HobbieId: '3',
    //    HobbieName: 'Chess',
    //    checked: false
    //}];
    $scope.InsertData = function () {
        
        var Action = document.getElementById("btnInsert").getAttribute("value");
        if (Action == "insert") {
            debugger;
            alert("hello");
            $scope.emp = {};
            $scope.emp.Ename =   $scope.EmpName;
            $scope.emp.Salary =  $scope.EmpSalary;
            $scope.emp.Gender =  $scope.selectedvalue;
            $scope.emp.Hobbies = $scope.selectedvalue0;
            $scope.emp.Hobbies1 = $scope.selectedvalue1;
            $scope.emp.Hobbies2 = $scope.selectedvalue2;
            $scope.emp.City =    $scope.Selectlist;

            $http({
                method: "post",
                url: 'Employee/AddEmployee',
                datatype: "json",
                data: JSON.stringify($scope.emp)
            }).then(function (response) {
                alert(response.data);
                $scope.EmpName;
                $scope.EmpSalary;
                $scope.selectedvalue;
                $scope.selectedvalue0;
                $scope.selectedvalue1;
                $scope.selectedvalue2;
                $scope.Selectlist;
                GetAllData
            })
        }
      
    };
    $scope.GetAllData = function () {

        $http({
            method: "get",
            url: 'Employee/List',
        }).then(function (response) {
            $scope.employees = response.data;
        }, function () {
            alert("Error Occur");
        })
    };
    $scope.DeleteEmp = function (Emp) {
        
        $http({
            method: "post",
            url: 'Employee/Delete',
            datatype: "json",
            data: JSON.stringify(Emp)
        }).then(function (response) {
            $scope.GetAllData();
        });
    };
  
});


//// For insert get update delete
//var app = angular.module("Crud", []);  
//app.controller("CRUDCONTROL", function($scope, $http) {  
//    debugger;  
//    $scope.InsertData = function() {  
//        var Action = document.getElementById("btnSave").getAttribute("value");  
//        if (Action == "Submit") {  
//            $scope.Employe = {};  
//            $scope.Employe.Emp_Name = $scope.EmpName;  
//            $scope.Employe.Emp_City = $scope.EmpCity;  
//            $scope.Employe.Emp_Age = $scope.EmpAge;  
//            $http({  
//                method: "post",  
//                url: "http://localhost:39209/Employee/Insert_Employee",  
//                datatype: "json",  
//                data: JSON.stringify($scope.Employe)  
//            }).then(function(response) {  
//                alert(response.data);  
//                $scope.GetAllData();  
//                $scope.EmpName = "";  
//                $scope.EmpCity = "";  
//                $scope.EmpAge = "";  
//            })  
//        } else {  
//            $scope.Employe = {};  
//            $scope.Employe.Emp_Name = $scope.EmpName;  
//            $scope.Employe.Emp_City = $scope.EmpCity;  
//            $scope.Employe.Emp_Age = $scope.EmpAge;  
//            $scope.Employe.Emp_Id = document.getElementById("EmpID_").value;  
//            $http({  
//                method: "post",  
//                url: "http://localhost:39209/Employee/Update_Employee",  
//                datatype: "json",  
//                data: JSON.stringify($scope.Employe)  
//            }).then(function(response) {  
//                alert(response.data);  
//                $scope.GetAllData();  
//                $scope.EmpName = "";  
//                $scope.EmpCity = "";  
//                $scope.EmpAge = "";  
//                document.getElementById("btnSave").setAttribute("value", "Submit");  
//                document.getElementById("btnSave").style.backgroundColor = "cornflowerblue";  
//                document.getElementById("spn").innerHTML = "Add New Employee";  
//            })  
//        }  
//    }  
//    $scope.GetAllData = function() {  
//        $http({  
//            method: "get",  
//            url: "http://localhost:39209/Employee/Get_AllEmployee"  
//        }).then(function(response) {  
//            $scope.employees = response.data;  
//        }, function() {  
//            alert("Error Occur");  
//        })  
//    };  
//    $scope.DeleteEmp = function(Emp) {  
//        $http({  
//            method: "post",  
//            url: "http://localhost:39209/Employee/Delete_Employee",  
//            datatype: "json",  
//            data: JSON.stringify(Emp)  
//        }).then(function(response) {  
//            alert(response.data);  
//            $scope.GetAllData();  
//        })  
//    };  
//    $scope.UpdateEmp = function(Emp) {  
//        document.getElementById("EmpID_").value = Emp.Emp_Id;  
//        $scope.EmpName = Emp.Emp_Name;  
//        $scope.EmpCity = Emp.Emp_City;  
//        $scope.EmpAge = Emp.Emp_Age;  
//        document.getElementById("btnSave").setAttribute("value", "Update");  
//        document.getElementById("btnSave").style.backgroundColor = "Yellow";  
//        document.getElementById("spn").innerHTML = "Update Employee Information";  
//    }  
//})  
//Now, provide the references of AngularJS and AngularCode file that we created into Index View.


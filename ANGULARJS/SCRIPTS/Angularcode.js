
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
    //$scope.selection = {
    //    name: { "Chess": true }
    //};

    //$scope.categories = [{ "name": "Chess", "id": "1" }, { "name": "Cricket", "id": "2" }];
    $scope.InsertData = function () {
        //INsert or UPDATE 
        var Action = document.getElementById("btnInsert").getAttribute("value");
        if (Action == "insert") {
            debugger;
            $scope.emp = {};
            $scope.emp.Ename = $scope.EmpName;
            $scope.emp.Ename =   $scope.EmpName;
            $scope.emp.Salary =  $scope.EmpSalary;
            $scope.emp.Gender = $scope.selectedvalue;
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
                debugger;
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpSalary = "";
                $scope.selectedvalue = "";
                $scope.selectedvalue0 = "";
                $scope.selectedvalue1 = "";
                $scope.selectedvalue2 = "";
                $scope.Selectlist = "";
                
            });
        }
        else {
            
            $scope.Employe = {};
            var a = document.getElementById("Eno").value;
            $scope.Employe.Eno = a;
            $scope.Employe.Ename = $scope.EmpName;
            $scope.Employe.Salary = $scope.EmpSalary;
            $scope.Employe.Gender = $scope.selectedvalue;
            $scope.Employe.Hobbies = $scope.selectedvalue0;
            $scope.Employe.Hobbies1 = $scope.selectedvalue1;
            $scope.Employe.Hobbies2 = $scope.selectedvalue2;
            $scope.Employe.City = $scope.Selectlist;
            $http({
                method: "post",
                url: 'Employee/Update',
                datatype: "json",
                data: JSON.stringify($scope.Employe)
            }).then(function (response) {
                alert(response.data);
                debugger;
                $scope.GetAllData();
                $scope.EmpName = "";
                $scope.EmpSalary = "";
                $scope.selectedvalue = "";
                $scope.selectedvalue0 = "";
                $scope.selectedvalue1 = "";
                $scope.selectedvalue2 = "";
                $scope.Selectlist = "";
                
                document.getElementById("btnInsert").setAttribute("value", "Submit");
                document.getElementById("btnInsert").style.backgroundColor = "cornflowerblue";
                document.getElementById("spn").innerHTML = "Add New Employee";
            })
        }  
      
    };

    //GET ALL DATA
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

    //DELETE EMP
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
    // EDIT
    $scope.UpdateEmp = function (Emp) {
        debugger;
        document.getElementById("Eno").value = Emp.Eno;
        $scope.EmpName = Emp.Ename;
        $scope.EmpSalary = Emp.Salary;
        $scope.selectedvalue = Emp.Gender;
        document.getElementById("chk").checked = Emp.Hobbies;
        document.getElementById("chk1").checked = Emp.Hobbies1;
        document.getElementById("chk2").checked = Emp.Hobbies2;
        $scope.selectedvalue0 = document.getElementById("chk").checked;
        $scope.selectedvalue1 = document.getElementById("chk1").checked;
        $scope.selectedvalue2 = document.getElementById("chk2").checked;
        $scope.Selectlist = Emp.City;
        document.getElementById("btnInsert").setAttribute("value", "Update");
        document.getElementById("btnInsert").style.backgroundColor = "Yellow";
        document.getElementById("spn").innerHTML = "Update Employee Information";
    };
});


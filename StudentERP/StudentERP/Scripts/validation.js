
$(document).ready(function () {
    //---------------------------------------Add_acadamic_year-----------------------------------------------------------------------
    $("#txt1").on("blur", function () {
        alert('hii');
        var nm = $("#txt1").val();
        regex = /^[0-9/-]+$/;
        if (nm == "") {
            alert('hello');
            $("#yr").text("Please Enter Year");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#yr").text("Only number allowed in Year");
                }
                else {
                    $("#yr").text("");
                }
            }
        }
    })

    //--------------------------------------------Add_board-----------------------------------------------------
    $("#bName").on("blur", function () {

        var nm = $("#bName").val();
        regex = /^[a-zA-z]*$/;
        if (nm == "") {

            $("#bn").text("Please Enter Board");
        }
        else
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#bn").text("Only alphabet allowed in Board");
                }
                else {
                    $("#bn").text("");
                }
            }

    })
    //-----------------------------------------------------Add_city------------------------------------------------------------------

    $("#cty").on("blur", function () {

        var nm = $("#cty").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#ct").text("Please Enter City");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#ct").text("Only alphabet allowed in City");
                }
                else {
                    $("#ct").text("");
                }
            }
        }
    });

    $("#State").blur(function () {
        var nm = $("#State").val();
        if (nm == '') {
            $("#sta").text("Field is required");
        }
        else {
            $("#sta").text("");
        }
    });

    //--------------------------------------------Add_country------------------------------------------------------------------------
    $("#Name").on("blur", function () {

        var nm = $("#Name").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#cntry").text("Please Enter Country");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#cntry").text("Only alphabet allowed in Country");
                }
                else {
                    $("#cntry").text("");
                }
            }
        }
    });




    //-------------------------------------------Add_division---------------------------------------------------
    $("#Name").on("blur", function () {

        var nm = $("#Name").val();
        regex = /^[a-zA-Z]+$/;
        if (nm == "") {

            $("#div").text("Please Enter Division");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#div").text("Only alphabet allowed in Division");
                }
                else {
                    $("#div").text("");
                }
            }
        }
    });

    //----------------------------------------------Add_fee_head--------------------------------------------------
    $("#fhName").on("blur", function () {

        var nm = $("#fhName").val();
        regex = /^[a-zA-Z]+$/;
        if (nm == "") {

            $("#fh").text("Please Enter Fee head");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#fh").text("Only alphabet allowed in Division");
                }
                else {
                    $("#fh").text("");
                }
            }
        }
    });


    //--------------------------------------------Add_occupation--------------------------------------------------

    $("#name").on("blur", function () {

        var nm = $("#name").val();
        regex = /^[a-zA-Z]+$/;
        if (nm == "") {

            $("#oc").text("Please Enter Occupation");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#oc").text("Only alphabet allowed in Occupation");
                }
                else {
                    $("#oc").text("");
                }
            }
        }
    });

    //----------------------------------------------Add_Qualification-----------------------------------
    $("#Name").on("blur", function () {

        var nm = $("#Name").val();
        regex = /^[a-zA-Z/.]+$/;
        if (nm == "") {

            $("#qu").text("Please Enter Qualification");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#qu").text("Only alphabet allowed in Qualification");
                }
                else {
                    $("#qu").text("");
                }
            }
        }
    });

    //-------------------------------------------Add religion----------------------------------------------------------------------

    $("#Name").on("blur", function () {

        var nm = $("#Name").val();
        regex = /^[a-zA-Z/.]*$/;
        if (nm == "") {

            $("#rg").text("Please Enter Religion");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#rg").text("Only alphabet allowed in Religion");
                }
                else {
                    $("#rg").text("");
                }
            }
        }
    });
    //------------------------------------------Add shift-----------------------------------------------------------------------------
    $("#shiftName").on("blur", function () {

        var nm = $("#shiftName").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#shft").text("Please Enter Shift");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#shft").text("Only alphabet allowed in Shift");
                }
                else {
                    $("#shft").text("");
                }
            }
        }
    });

    //-------------------------------------------Add Standard-----------------------------------------------------

    $("#name").on("blur", function () {

        var nm = $("#name").val();
        regex = /^[0-9]+$/;
        if (nm == "") {

            $("#std").text("Please Enter Standard");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#std").text("Only number allowed in Standard");
                }
                else {
                    $("#std").text("");
                }
            }
        }
    });

    $("#LevelOfStd").on("blur", function () {

        var nm = $("#LevelOfStd").val();
        regex = /^[0-9]+$/;
        if (nm == "") {

            $("#lvl").text("Please Enter Level of standard");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#lvl").text("Only number allowed in Level of standard");
                }
                else {
                    $("#lvl").text("");
                }
            }
        }
    });

    //---------------------------------------------------Add state-----------------------------------------------------

    $("#Country").blur(function () {
        // alert('sdgg fdfgdfg');
        var nm = $("#Country").val();
        //alert(nm);
        if (nm == '') {
            // alert('sfgsd');
            $("#cnty").text("Field is required");
        }
    });



    $("#stat").on("blur", function () {

        var nm = $("#stat").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#st").text("Please Enter State");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#st").text("Only  alphabet allowed in State");
                }
                else {
                    $("#st").text("");
                }
            }
        }
    });


    //------------------------------------------------Add Subject-----------------------------------------------------------------
    $("#Name").on("blur", function () {

        var nm = $("#Name").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#sub").text("Please Enter Subject");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#sub").text("Only alphabet allowed in Subject");
                }
                else {
                    $("#sub").text("");
                }
            }
        }
    });

    //-----------------------------Add user-------------------------------------------------------------------

    $("#lgn").on("blur", function () {

        var nm = $("#lgn").val();
        regex = /^[0-9]+$/;
        if (nm == "") {

            $("#lg").text("Please Enter LoginId");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#lg").text("Only number allowed in LoginId");
                }
                else {
                    $("#lg").text("");
                }
            }
        }
    });


    $("#pwd").on("blur", function () {

        var nm = $("#pwd").val();
        regex = /^[0-9]+$/;
        if (nm == "") {

            $("#pd").text("Please Enter Password");
        }
        else {

            $("#pd").text("");
        }
    });


    $("#fname").on("blur", function () {

        var nm = $("#fname").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#fnm").text("Please Enter Firstname");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#fnm").text("Only alphabet allowed in Firstname");
                }
                else {
                    $("#fnm").text("");
                }
            }
        }
    });


    $("#mname").on("blur", function () {

        var nm = $("#mname").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#mnm").text("Please Enter Middlename");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#mnm").text("Only alphabet allowed in Middlename");
                }
                else {
                    $("#mnm").text("");
                }
            }
        }
    });


    $("#lname").on("blur", function () {

        var nm = $("#lname").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#lnm").text("Please Enter Lastname");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#lnm").text("Only alphabet allowed in Lastname");
                }
                else {
                    $("#lnm").text("");
                }
            }
        }
    });

    $("#dob").on("blur", function () {

        var nm = $("#dob").val();
        regex = /^[0-9]+$/;
        if (nm == "") {

            $("#db").text("Please Enter Birthdate");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#db").text("Only number allowed in Birthdate");
                }
                else {
                    $("#db").text("");
                }
            }
        }
    });

    $("#email").on("blur", function () {

        var nm = $("#email").val();
        regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;
        if (nm == "") {

            $("#em").text("Please Enter Email");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#em").text("Please fill proper Email");
                }
                else {
                    $("#em").text("");
                }
            }
        }
    });

    //------------------------------------------------Admin login---------------------------------------------


    $("#email").on("blur", function () {

        var nm = $("#email").val();
        regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;
        if (nm == "") {

            $("#eml").text("Please Enter Email");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#eml").text("Please fill proper Email");
                }
                else {
                    $("#eml").text("");
                }
            }
        }
    });

    $("#pwd").on("blur", function () {

        var nm = $("#pwd").val();
        regex = /^[0-9]+$/;
        if (nm == "") {

            $("#ps").text("Please Enter Password");
        }
        else {

            $("#ps").text("");
        }
    });


    //-------------------------------------Change Password---------------------------------------------------

    $("#opwd").on("blur", function () {

        var nm = $("#opwd").val();
        regex = /^[a-zA-Z0-9]+$/;
        if (nm == "") {

            $("#op").text("Please Enter  Old Password");
        }
        else {

            $("#op").text("");
        }
    });


    $("#npwd").on("blur", function () {

        var nm = $("#npwd").val();
        regex = /^[a-zA-Z0-9]+$/;
        if (nm == "") {

            $("#np").text("Please Enter New Password");
        }
        else {

            $("#np").text("");
        }
    });



    $("#cpwd").on("blur", function () {

        var nm = $("#cpwd").val();
        regex = /^[a-zA-Z0-9]+$/;
        if (nm == "") {

            $("#cp").text("Please Enter Confirm Password");
        }
        else {

            $("#cp").text("");
        }
    });

    //------------------------------------Forgot Password----------------------------------------------------------

    $("#email").on("blur", function () {

        var nm = $("#email").val();
        regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;
        if (nm == "") {

            $("#ema").text("Please Enter Email");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#ema").text("Please fill proper Email");
                }
                else {
                    $("#ema").text("");
                }
            }
        }
    });

    //------------------------Add Assignment and worksheet--------------------------------------------------

    $("#TeacherName").blur(function () {
        //alert('sdgg fdfgdfg');
        var nm = $("#TeacherName").val();
        //alert(nm);
        if (nm == '') {
            // alert('sfgsd');
            $("#tnm").text("Field is required");
        }
        else {
            $("#tnm").text("");
        }
    });



    $("#FileUpload1").blur(function () {
        // alert('sdgg fdfgdfg');
        var nm = $("#FileUpload1").val();
        regex = /^([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf|.png|.jpg|.gif|.txt|.xls|.xlsx|.rar)$/;
        if (nm == "") {

            $("#fu").text("Please Choose The File");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#fu").text("Please Select Proper File");
                }
                else {
                    $("#fu").text("");
                }
            }
        }

    });


    $("#Standard").blur(function () {
        // alert('sdgg fdfgdfg');
        var nm = $("#Standard").val();
        //alert(nm);
        if (nm == '') {
            // alert('sfgsd');
            $("#st").text("Field is required");
        }
        else {
            $("#st").text("");
        }
    });


    $("#atitl").on("blur", function () {

        var nm = $("#atitl").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#ati").text("Please Enter Assignment Title");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#ati").text("Only alphabet allowed in Assignment Title");
                }
                else {
                    $("#ati").text("");
                }
            }
        }
    });

    $("#descrp").on("blur", function () {

        var nm = $("#descrp").val();
        regex = /^[a-zA-Z|0-9]*$/;
        if (nm == "") {

            $("#des").text("Please Enter Assignment Title");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#des").text("Only alphabet allowed in Assignment Title");
                }
                else {
                    $("#des").text("");
                }
            }
        }
    });


    //----------------------------------------------Add emp type-------------------------------------------------


    $("#emptype_name").on("blur", function () {

        var nm = $("#emptype_name").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#empnam").text("Please Enter Employee type name");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#empnam").text("Only alphabet allowed in Employee type name");
                }
                else {
                    $("#empnam").text("");
                }
            }
        }
    });
    //----------------------------------------Add events---------------------------------------------------------

    $("#Type").blur(function () {
        var nm = $("#Type").val();
        if (nm == '') {
            $("#tp").text("Field is required");
        }
        else {
            $("#tp").text("");
        }
    });

    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#st").text("Field is required");
        }
        else {
            $("#st").text("");
        }
    });


    $("#Division").blur(function () {
        var nm = $("#Division").val();
        if (nm == '') {
            $("#dv").text("Field is required");
        }
        else {
            $("#dv").text("");
        }
    });



    $("#titl").on("blur", function () {

        var nm = $("#titl").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#tit").text("Please Enter Title");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#tit").text("Only alphabet allowed in Title");
                }
                else {
                    $("#tit").text("");
                }
            }
        }
    });


    $("#sdate").on("blur", function () {

        var nm = $("#sdate").val();
        regex = /^[0-9/:]*$/;
        if (nm == "") {

            $("#sdt").text("Please Enter Start Date");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#sdt").text("Only number allowed in Start Date");
                }
                else {
                    $("#sdt").text("");
                }
            }
        }
    });



    $("#edate").on("blur", function () {

        var nm = $("#edate").val();
        regex = /^[0-9/:]*$/;
        if (nm == "") {

            $("#edt").text("Please Enter End Date");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#edt").text("Only number allowed in End Date");
                }
                else {
                    $("#edt").text("");
                }
            }
        }
    });



    $("#descrp").on("blur", function () {

        var nm = $("#descrp").val();
        regex = /^[a-zA-Z/./,]*$/;
        if (nm == "") {

            $("#desc").text("Please Enter Description");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#desc").text("Please enter proper description");
                }
                else {
                    $("#desc").text("");
                }
            }
        }
    });

    //-------------------------------Add exam----------------------------------------------------------------

    $("#Term").blur(function () {
        var nm = $("#Term").val();
        if (nm == '') {
            $("#tm").text("Field is required");
        }
        else {
            $("#tm").text("");
        }
    });

    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#sd").text("Field is required");
        }
        else {
            $("#sd").text("");
        }
    });


    $("#lable").on("blur", function () {

        var nm = $("#lable").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#lbl").text("Please Enter Label");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#lbl").text("Please enter proper Label");
                }
                else {
                    $("#lbl").text("");
                }
            }
        }
    });

    //--------------------------------Add notification-------------------------------------------------------


    $("#Type").blur(function () {
        var nm = $("#Type").val();
        if (nm == '') {
            $("#tp").text("Field is required");
        }
        else {
            $("#tp").text("");
        }
    });


    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#sd").text("Field is required");
        }
        else {
            $("#sd").text("");
        }
    });


    $("#Division").blur(function () {
        var nm = $("#Division").val();
        if (nm == '') {
            $("#dv").text("Field is required");
        }
        else {
            $("#dv").text("");
        }
    });

    $("#titl").on("blur", function () {

        var nm = $("#titl").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#tt").text("Please Enter Title");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#tt").text("Only alphabet allowed in Title");
                }
                else {
                    $("#tt").text("");
                }
            }
        }
    });


    $("#sdate").on("blur", function () {

        var nm = $("#sdate").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#sda").text("Please Enter Start date");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#sda").text("Only number allowed in Start date");
                }
                else {
                    $("#sda").text("");
                }
            }
        }
    });


    $("#edate").on("blur", function () {

        var nm = $("#edate").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#eda").text("Please Enter End date");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#eda").text("Only number allowed in End date");
                }
                else {
                    $("#eda").text("");
                }
            }
        }
    });


    $("#sname").on("blur", function () {

        var nm = $("#sname").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#snm").text("Please Enter Student name");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#snm").text("Only alphabet allowed in Student name");
                }
                else {
                    $("#snm").text("");
                }
            }
        }
    });


    $("#tname").on("blur", function () {

        var nm = $("#tname").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#tnm").text("Please Enter Teacher name");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#tnm").text("Only alphabet allowed in Teacher name");
                }
                else {
                    $("#tnm").text("");
                }
            }
        }
    });


    $("#descrp").on("blur", function () {

        var nm = $("#descrp").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#des").text("Please Enter Description");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#des").text("Please enter proper Description ");
                }
                else {
                    $("#des").text("");
                }
            }
        }
    });

    //---------------------------Add school details--------------------------------------------------------------------------------

    $("#schoolName").on("blur", function () {

        var nm = $("#schoolName").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#scnm").text("Please Enter School Name");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#scnm").text("Only alphabet allowed in School Name");
                }
                else {
                    $("#scnm").text("");
                }
            }
        }
    });

    $("#schoolAddress").on("blur", function () {

        var nm = $("#schoolAddress").val();
        regex = /^[a-zA-Z+0-9]*$/;
        if (nm == "") {

            $("#scadd").text("Please Enter School Address");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#scadd").text("Only alphabet allowed in School Address");
                }
                else {
                    $("#scadd").text("");
                }
            }
        }
    });

    $("#schoolwebsite").on("blur", function () {

        var nm = $("#schoolwebsite").val();
        regex = /(http(s)?:\\)?([\w-]+\.)+[\w-]+[.com|.in|.org]+(\[\?%&=]*)?/;
        if (nm == "") {

            $("#schweb").text("Please Enter School Website");
        }

        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#schweb").text("Please Enter Proper School Address");
                }
                else {
                    $("#schweb").text("");
                }
            }
        }
    });


    $("#office").on("blur", function () {

        var nm = $("#office").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#ofce").text("Please Enter Office number");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#ofce").text("Only number allowed in Office number");
                }
                else {
                    $("#ofce").text("");
                }
            }
        }
    });


    $("#mobNum").on("blur", function () {

        var nm = $("#mobNum").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#mbnm").text("Please Enter Mobile number");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#mbnm").text("Only number allowed in Mobile number");
                }
                else {
                    $("#mbnm").text("");
                }
            }
        }
    });

    //-----------------------------------------Add standard division shift---------------------------------------

    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#sd").text("Field is required");
        }
        else {
            $("#sd").text("");
        }
    });

    $("#Division").blur(function () {
        var nm = $("#Division").val();
        if (nm == '') {
            $("#dv").text("Field is required");
        }
        else {
            $("#dv").text("");
        }
    });

    $("#AcadamicYear").blur(function () {
        var nm = $("#AcadamicYear").val();
        if (nm == '') {
            $("#yr").text("Field is required");
        }
        else {
            $("#yr").text("");
        }
    });

    $("#Shift").blur(function () {
        var nm = $("#Shift").val();
        if (nm == '') {
            $("#sf").text("Field is required");
        }
        else {
            $("#sf").text("");
        }
    });


    $("#stime").on("blur", function () {

        var nm = $("#stime").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#ste").text("Please Enter Start time");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#ste").text("Only number allowed in Start time");
                }
                else {
                    $("#ste").text("");
                }
            }
        }
    });

    $("#etime").on("blur", function () {

        var nm = $("#etime").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#ete").text("Please Enter End Time");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#ete").text("Only number allowed in End Time");
                }
                else {
                    $("#ete").text("");
                }
            }
        }
    });

    //---------------------------------------Add student according acadamic year----------------------------------

    $("#AcadamicYear").blur(function () {
        var nm = $("#AcadamicYear").val();
        if (nm == '') {
            $("#yr").text("Field is required");
        }
        else {
            $("#yr").text("");
        }
    });


    $("#Standard_Division").blur(function () {
        var nm = $("#Standard_Division").val();
        if (nm == '') {
            $("#dv").text("Field is required");
        }
        else {
            $("#dv").text("");
        }
    });




    $("#sname").on("blur", function () {

        var nm = $("#sname").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#sm").text("Please Enter Student Name");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#sm").text("Only alphabet allowed in Student Name");
                }
                else {
                    $("#sm").text("");
                }
            }
        }
    });


    $("#rollno").on("blur", function () {

        var nm = $("#rollno").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#roll").text("Please Enter Roll No.");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#roll").text("Only number allowed in Roll No.");
                }
                else {
                    $("#roll").text("");
                }
            }
        }
    });

    //--------------------------------------Add Teacher{Employee}--------------------------------------------------------------------

    $("#EmpType").blur(function () {
        var nm = $("#EmpType").val();
        if (nm == '') {
            $("#et").text("Field is required");
        }
        else {
            $("#et").text("");
        }
    });




    $("#Password").on("blur", function () {

        var nm = $("#Password").val();
        regex = /^[0-9a-zA-Z]*$/;
        if (nm == "") {

            $("#pd").text("Please Enter Password");
        }

        else {
            $("#pd").text("");
        }
    });

    $("#FirstName").on("blur", function () {

        var nm = $("#FirstName").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#finm").text("Please Enter Firstname");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#finm").text("Only alphabet allowed in Firstname");
                }
                else {
                    $("#finm").text("");
                }
            }
        }
    });


    $("#MiddleName").on("blur", function () {

        var nm = $("#MiddleName").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#minm").text("Please Enter Middle Name");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#minm").text("Only alphabet allowed in Middle Name");
                }
                else {
                    $("#minm").text("");
                }
            }
        }
    });

    $("#LastName").on("blur", function () {

        var nm = $("#LastName").val();
        regex = /^[a-zA-Z]*$/;
        if (nm == "") {

            $("#lanm").text("Please Enter Last Name");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#lanm").text("Only alphabet allowed in Last Name");
                }
                else {
                    $("#lanm").text("");
                }
            }
        }
    });

    $("#Birthdate").on("blur", function () {

        var nm = $("#Birthdate").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#bid").text("Please Enter Birthdate");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#bid").text("Only number allowed in Birthdate");
                }
                else {
                    $("#bid").text("");
                }
            }
        }
    });

    $("#Email").on("blur", function () {

        var nm = $("#Email").val();
        regex = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/;
        if (nm == "") {

            $("#eil").text("Please Enter Email");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#eil").text("Please Enter Proper Email");
                }
                else {
                    $("#eil").text("");
                }
            }
        }
    });

    $("#ContactNo").on("blur", function () {

        var nm = $("#ContactNo").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#cno").text("Please Enter Contact No.");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#cno").text("Only number allowed in Contact No.");
                }
                else {
                    $("#cno").text("");
                }
            }
        }
    });

    $("#Address").on("blur", function () {

        var nm = $("#Address").val();
        regex = /^[a-zA-Z0-9]*$/;
        if (nm == "") {

            $("#addr").text("Please Enter Address");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#addr").text("Please Enter Proper Address");
                }
                else {
                    $("#addr").text("");
                }
            }
        }
    });



    $("input[name='Gender']").blur(function () {
        var chk = $(this).is(":checked");
        //alert('hello');
        if (chk == false) {
            $("#rd").text("Please Select The Gender");

        }
        else {

            $("#rd").text("");
        }
    });

    //-----------------------------Standard Shift according fees---------------------------------------------

    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#sd").text("Field is required");
        }
        else {
            $("#sd").text("");
        }
    });


    $("#Shift").blur(function () {
        var nm = $("#Shift").val();
        if (nm == '') {
            $("#sf").text("Field is required");
        }
        else {
            $("#sf").text("");
        }
    });


    $("#FeesHead").blur(function () {
        var nm = $("#FeesHead").val();
        if (nm == '') {
            $("#fd").text("Field is required");
        }
        else {
            $("#fd").text("");
        }
    });


    $("#fees").on("blur", function () {

        var nm = $("#fees").val();
        regex = /^[0-9]*$/;
        if (nm == "") {

            $("#fe").text("Please Enter Fess");
        }
        else {
            if (nm != "") {
                if (!nm.match(regex)) {
                    $("#fe").text("Only number allowed in fees");
                }
                else {
                    $("#fe").text("");
                }
            }
        }
    });
    //------------------------Add board wies school--------------------------------------------
    $("#Board").blur(function () {
        // alert('sdgg fdfgdfg');
        var nm = $("#Board").val();
        // alert(nm);
        if (nm == '') {
            // alert('sfgsd');
            $("#bd").text("Field is required");
        }
        else {
            $("#bd").text("");
        }
    });

    $("#School").blur(function () {
        // alert('sdgg fdfgdfg');
        var nm = $("#School").val();
        // alert(nm);
        if (nm == '') {
            // alert('sfgsd');
            $("#sd").text("Field is required");
        }
        else {
            $("#sd").text("");
        }
    });
    //-----------------------------Add class teacher----------------------------------------

    $("#TeacherName").blur(function () {
        var nm = $("#TeacherName").val();
        if (nm == '') {
            $("#tm").text("Field is required");
        }
        else {
            $("#tm").text("");
        }
    });

    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#td").text("Field is required");
        }
        else {
            $("#td").text("");
        }
    });


    $("#Division").blur(function () {
        var nm = $("#Division").val();
        if (nm == '') {
            $("#dv").text("Field is required");
        }
        else {
            $("#dv").text("");
        }
    });

    $("#AcadamicYear").blur(function () {
        var nm = $("#AcadamicYear").val();
        if (nm == '') {
            $("#ay").text("Field is required");
        }
        else {
            $("#ay").text("");
        }
    });
    //----------------------Add exam standard--------------------------------------------------

    $("#Exam").blur(function () {
        var nm = $("#Exam").val();
        if (nm == '') {
            $("#em").text("Field is required");
        }
        else {
            $("#em").text("");
        }
    });


    $("#Standard_Division").blur(function () {
        var nm = $("#Standard_Division").val();
        if (nm == '') {
            $("#dv").text("Field is required");
        }
        else {
            $("#dv").text("");
        }
    });
    //------------------------Add standard wies division---------------------------------------------

    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#sd").text("Field is required");
        }
        else {
            $("#sd").text("");
        }
    });

    $("#Division").blur(function () {
        var nm = $("#Division").val();
        if (nm == '') {
            $("#dv").text("Field is required");
        }
        else {
            $("#dv").text("");
        }
    });

    $("#Year").blur(function () {
        var nm = $("#Year").val();
        if (nm == '') {
            $("#yr").text("Field is required");
        }
        else {
            $("#yr").text("");
        }
    });
    //----------------------------------Add standard wies subject-------------------------------

    $("#Year").blur(function () {
        var nm = $("#Year").val();
        if (nm == '') {
            $("#yr").text("Field is required");
        }
        else {
            $("#yr").text("");
        }
    });

    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#sd").text("Field is required");
        }
        else {
            $("#sd").text("");
        }
    });

    $("#Subject").blur(function () {
        var nm = $("#Subject").val();
        if (nm == '') {
            $("#sb").text("Field is required");
        }
        else {
            $("#sb").text("");
        }
    });

    $("input[name='type']").blur(function () {
        var chk = $(this).is(":checked");
        //alert('hello');
        if (chk == false) {
            $("#rd").text("Please Select The Type");

        }
        else {

            $("#rd").text("");
        }
    })
    //-------------------------------------Add subject teacher----------------------------------
    $("#Subject").blur(function () {
        var nm = $("#Subject").val();
        if (nm == '') {
            $("#sb").text("Field is required");
        }
        else {
            $("#sb").text("");
        }
    });

    $("#TeacherName").blur(function () {
        var nm = $("#TeacherName").val();
        if (nm == '') {
            $("#tm").text("Field is required");
        }
        else {
            $("#tm").text("");
        }
    });


    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#sd").text("Field is required");
        }
        else {
            $("#sd").text("");
        }
    });


    $("#Division").blur(function () {
        var nm = $("#Division").val();
        if (nm == '') {
            $("#dv").text("Field is required");
        }
        else {
            $("#dv").text("");
        }
    });

    $("#AcadamicYear").blur(function () {
        var nm = $("#AcadamicYear").val();
        if (nm == '') {
            $("#yr").text("Field is required");
        }
        else {
            $("#yr").text("");
        }
    });
    //------------------------------Add standard according year---------------------------------------------------


    $("#Standard").blur(function () {
        var nm = $("#Standard").val();
        if (nm == '') {
            $("#as").text("Field is required");
        }
        else {
            $("#as").text("");
        }
    });


    $("#AcadamicYear").blur(function () {
        var nm = $("#AcadamicYear").val();
        if (nm == '') {
            $("#ay").text("Field is required");
        }
        else {
            $("#ay").text("");
        }
    });


    $("#StartMonth").blur(function () {
        var nm = $("#StartMonth").val();
        if (nm == '') {
            $("#sm").text("Field is required");
        }
        else {
            $("#sm").text("");
        }
    });


    $("#EndMonth").blur(function () {
        var nm = $("#EndMonth").val();
        if (nm == '') {
            $("#eth").text("Field is required");
        }
        else {
            $("#eth").text("");
        }

    });
   

   
})
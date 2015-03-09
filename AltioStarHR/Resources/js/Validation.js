
//For Validation 

//For Empty text Validation

function IsEmpty(id) {
    try {
        if (document.getElementById(id).value == "")
            return true;
        return false;
    }
    catch (e) {
        return false;
    }
}

//Text validation
//minimum length and max length
function validateText(id, min, max) { 
    try {
        if (document.getElementById(id).value.length < min)
            return false;
        if (max) {
            if (document.getElementById(id).value.length > max)
                return false;
        }
        return true;
    }
    catch (e) {
        return false;
    }
}

//password validate
//minimum length and max length
function validatePassword(id, min, max) {
    try {
        if (document.getElementById(id).value.length < min)
            return false;
        if (max) {
            if (document.getElementById(id).value.length > max)
                return false;
        }
        return true;
    }
    catch (e) {
        return false;
    }
}

//password equals confirm password check
function checkPasswordConfirmPassword(idPassword, idConfirmPassword) {
    try {
        if (document.getElementById(idPassword).value !=
     document.getElementById(idConfirmPassword).value)
            return false;
        return true;
    }
    catch (e) {
        return false;
    }
}

//success - name@domain.com, name@domain.co, name@domain.co.in
//fail - fgder56, @ghdg, fsfs.fgg, dsfsdf@fsdf.h
function validateEmailId(id) {
    try {
        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        if (!emailPattern.test(document.getElementById(id).value))
            return false;

        return true;
    }
    catch (e) {
        return false;
    }
}

//10digit mobile number
//success - +91123456789, 123456789
//fail - 1234, +91235
function validateMobileNo(id) {
    try {
        var mobilePattern = /^(\+(\d{2}))?(\d{10}){1}?$/;
        if (!mobilePattern.test(document.getElementById(id).value))
            return false;
        return true;
    }
    catch (e) {
        return false;
    }
}

//check date1<date2
function dateComparison(date1, date2) {
    var day1;
    var day2;
    var month1;
    var month2;
    var year1;
    var year2;

    var date1arr = date1.split("/");
    day1 = date1arr[0];
    month1 = date1arr[1];
    year1 = date1arr[2];

    var date2arr = date2.split("/");
    day2 = date2arr[0];
    month2 = date2arr[1];
    year2 = date2arr[2];

    if (eval(year1) < eval(year2))
        return true;
    else if (eval(year1) > eval(year2))
        return false;
    if (eval(month1) < eval(month2))
        return true;
    else if (eval(month1) > eval(month2))
        return false;
    if (eval(day1) <= eval(day2))
        return true;

    return false;

}

//success - 2.45, 0.00, 45345, 43534.30, 0
//fail - 2323., 233.2, .23, .2, 0., .00, ghjdh435
function checkPrice(id) {
    try {
        var Price = document.getElementById(id).value;
        if (Price == "")
            return false;
        else {
            var pricePattern = /^[0-9]+(,[0-9]{3})*(\.[0-9]{2})?$/;

            if (!pricePattern.test(Price))
                return false;
        }
        return true;
    }
    catch (e) {
        return false;
    }
}

//validate number
//success - 0, 23123213, 0345435
//fail - dsf324234, 234.23423
function checkNumber(id) {
    try {
        var num = document.getElementById(id).value;
        if (num == "")
            return false;
        else {
            var numberPattern = /^[+]?\d*$/;

            if (!numberPattern.test(num))
                return false;
        }
        return true;
    }
    catch (e) {
        return false;
    }
}

//onkeypress
//success - 245, 45345, 0
//fail - 2323., 233.2, .23, .2, 0., .00, sgfsg5345
function OnlyNumbers(e) {
    try {
        var charact = (e.keyCode) ? e.keyCode : ((e.charCode) ? e.charCode : e.which);

        if (charact == 8)

            return true;

        if (charact < 48 || charact > 57) {
            charact = 0;
            return false;
        }

        return true;
    }
    catch (e) {
        return false;
    }
}

//onkeypress
//success - 245, 45345, 0
//fail - 2323., 233.2, .23, .2, 0., .00, sgfsg5345
function OnlyNumbersN(e, n) {
    try {
        var charact = (e.keyCode) ? e.keyCode : ((e.charCode) ? e.charCode : e.which);

        if (charact == 8)

            return true;

        if (charact < 48 || charact > 57) {
            charact = 0;
            return false;
        }

        var id;

        if (e.srcElement)
            id = e.srcElement.id;
        else
            id = e.target.id;


        if (document.getElementById(id).value.length > n)
            return false;

        return true;
    }
    catch (e) {
        return false;
    }
}

//onkeypress
//success - 2.45, 0.00, 45345, 43534.30, 0, 43534.3, 2323., .23, 0., .00
//fail - gdfg565
function OnlyNumbersWithPeriod(e) {
    try {
        var charact = (e.keyCode) ? e.keyCode : ((e.charCode) ? e.charCode : e.which);

        if (charact == 8 || charact == 46)

            return true;

        if (charact < 48 || charact > 57) {
            charact = 0;
            return false;
        }

        return true;
    }
    catch (e) {
        return false;
    }
}

//on keypress
//including space
//success - gfhgf43534, gj ghfgh, 4534667 54
//fail - #%$%fghgf, hfdh-fjj34
function OnlyAlphaNumerics(e) {
    try {
        var charact = (e.keyCode) ? e.keyCode : ((e.charCode) ? e.charCode : e.which);

        if (charact == 8 || charact == 32)
            return true;

        if (charact < 48 || charact > 122) {
            charact = 0;
            return false;
        }
        else {

            if (charact > 57 && charact < 65) {
                charact = 0;
                return false;
            }
            if (charact > 90 && charact < 97) {
                charact = 0;
                return false;
            }

        }
        return true;
    }
    catch (e) {
        return false;
    }
}

//onkeypress
//including space
//success - gfhgf, gj ghfgh, fdgEv
//fail - #%$%fghgf, gf546hgffhgh, hfdh-fjj34, 4534667 54
function OnlyAlphabets(e) {
    try {
        var charact = (e.keyCode) ? e.keyCode : ((e.charCode) ? e.charCode : e.which);

        if (charact == 8 || charact == 32)
            return true;

        if (charact < 65 || charact > 122) {
            charact = 0;
            return false;
        }
        else if (charact > 90 && charact < 97) {
            charact = 0;
            return false;
        }
        return true;
    }
    catch (e) {
        return false;
    }
}
   // compare two date 
   function ValidateDate(StartDate,EndDate) {
       
            var CurrentDate = new Date();
            var curr_date = CurrentDate.getDate();
            var curr_month = CurrentDate.getMonth()+1;
            var curr_year = CurrentDate.getFullYear();
            var MCurrentDate=curr_date+"/"+curr_month+"/"+curr_year;
         
         if(!CompareDate(StartDate,MCurrentDate,true,'Start') || !CompareDate(EndDate,MCurrentDate,true,'End') || !CompareDate(StartDate,EndDate,false,'Both'))
         {
           return false;
         }   
         else{
           return true;
         }
      } 
      // compare given date should less than today date 
      function ValidateSingleDate(SDate,DateType) {
         
            var CurrentDate = new Date();
            var curr_date = CurrentDate.getDate();
            var curr_month = CurrentDate.getMonth()+1;
            var curr_year = CurrentDate.getFullYear();
            var MCurrentDate=curr_date+"/"+curr_month+"/"+curr_year;
         
         if(!CompareDate(SDate,MCurrentDate,true,DateType))
         {
           return false;
         }   
         else{
           return true;
         }
      } 
      function CompareDate(StartDate,EndDate,CompareToday,DateType) {
      
        var DateFrm =StartDate; 
         var DateTo = EndDate; 
         if(DateFrm==null){return false;}
         if (DateTo == null) { return false; }
         
          var SplitDateFrm = DateFrm.split("/");
         
         var DateFrmDay = eval(SplitDateFrm[0]);
         var DateFrmMonth = eval(SplitDateFrm[1]);
         var DateFrmYear = eval(SplitDateFrm[2]);
         
         var SplitDateTo = DateTo.split("/");
         
         var DateToDay = eval(SplitDateTo[0]);
         var DateToMonth = eval(SplitDateTo[1]);
         var DateToYear = eval(SplitDateTo[2]);
         
         if(DateFrmYear == DateToYear)
             {         
                if(DateFrmMonth == DateToMonth)
                {
                    if(DateToDay<DateFrmDay)
                    {
                        if(CompareToday==true) alert(DateType+' Date cannot be after Today Date.');
                        else alert('Start Date cannot be after End Date.');
                        return false;
                    }
                    if(DateToDay==DateFrmDay)
                    {
                        if(CompareToday==true) alert(DateType+' Date cannot be equal to Today Date.');
                        else
                         alert('Start Date cannot be equal to End Date.');
                         return false;
                    }
                }
                else if(DateFrmMonth > DateToMonth)
                {
                    if(CompareToday==true) alert(DateType+' Date cannot be after Today Date.');
                    else
                    alert('Start Date cannot be after End Date.');
                    return false;
                }
             }
             else if(DateFrmYear > DateToYear)
             {
                        if(CompareToday==true) alert(DateType+' Date cannot be after Today Date.');
                        else
                        alert('Start Date cannot be after End Date.');
                        return false;
             }
          return true;
      }
      
      
      
      // funstion to validate date for reports
      function CompareDateForReport(StartDate,EndDate) {
        var DateFrm =StartDate; 
         var DateTo = EndDate;

         if (DateFrm == null || DateFrm=="") { alert("From Date should not be empty."); return false; }
         if (DateTo == null || DateTo=="") { alert("To Date should not be empty."); return false; }
         
          var SplitDateFrm = DateFrm.split("/");
         
         var DateFrmDay = eval(SplitDateFrm[0]);
         var DateFrmMonth = eval(SplitDateFrm[1]);
         var DateFrmYear = eval(SplitDateFrm[2]);
         
         var SplitDateTo = DateTo.split("/");
         
         var DateToDay = eval(SplitDateTo[0]);
         var DateToMonth = eval(SplitDateTo[1]);
         var DateToYear = eval(SplitDateTo[2]);
         
         if(DateFrmYear == DateToYear)
             {         
                if(DateFrmMonth == DateToMonth)
                {
                    if(DateToDay<DateFrmDay)
                    {
                        //if(CompareToday==true) alert(DateType+' Date cannot be after Today Date.');
                        //else 
                        alert('From Date cannot be after To Date.');
                        return false;
                    }
                    else{
                        return true;
                    }
//                    if(DateToDay==DateFrmDay)
//                    {
//                        //if(CompareToday==true) alert(DateType+' Date cannot be equal to Today Date.');
//                        //else
//                         alert('Start Date cannot be equal to End Date.');
//                         return false;
//                    }
                }
                else if(DateFrmMonth > DateToMonth)
                {
                    //if(CompareToday==true) alert(DateType+' Date cannot be after Today Date.');
                   // else
                    alert('From Date cannot be after To Date.');
                    return false;
                }
             }
             else if(DateFrmYear > DateToYear)
             {
                        //if(CompareToday==true) alert(DateType+' Date cannot be after Today Date.');
                        //else
                        alert('From Date cannot be after To Date.');
                        return false;
             }
          return true;
      }
      function CompareDateForForm(StartDate, EndDate) {
          var DateFrm = StartDate;
          var DateTo = EndDate;

          if (DateFrm == null || DateFrm == "") { alert("Start Date should not be empty."); return false; }
          if (DateTo == null || DateTo == "") { alert("End Date should not be empty."); return false; }

          var SplitDateFrm = DateFrm.split("/");

          var DateFrmDay = eval(SplitDateFrm[0]);
          var DateFrmMonth = eval(SplitDateFrm[1]);
          var DateFrmYear = eval(SplitDateFrm[2]);

          var SplitDateTo = DateTo.split("/");

          var DateToDay = eval(SplitDateTo[0]);
          var DateToMonth = eval(SplitDateTo[1]);
          var DateToYear = eval(SplitDateTo[2]);

          if (DateFrmYear == DateToYear) {
              if (DateFrmMonth == DateToMonth) {
                  if (DateToDay < DateFrmDay) {
                      //alert('Start Date cannot be after End Date.');
                      return false;
                  }
                  else {
                      return true;
                  }
              }
              else if (DateFrmMonth > DateToMonth) {
                  //alert('Start Date cannot be after End Date.');
                  return false;
              }
          }
          else if (DateFrmYear > DateToYear) {
              //alert('Start Date cannot be after End Date.');
              return false;
          }
          return true;
      }
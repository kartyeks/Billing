using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRCAKernel.Communication;
using HRManager.Entity.EmployeesInfo;
using IRCAKernel;
using HRManager.BusinessObjects;
using HRManager.DTOEXT.Employees;
using HRManager.DTO;
using System.Data;

namespace HRManager.Entity.EmployeeLeave
{
    public class LeaveRequestNotification
    {
        private static String EmployeeLeaveRequest =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " <b>A leave request has been raised. Kindly approve / reject the request.</b>"
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{1}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeLeaveRequestSendToHR =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " <b>A leave request has been raised. Kindly review.</b>"
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{1}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeLeaveRequestSendToAdmin =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " <b> A leave request has been raised. Kindly review.</b>"
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{1}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeLeaveRequestAPP =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that your leave request has been approved by your Manager <b>{1}</b>."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{0}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeLeaveRequestAPPSendToHR =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + "  A leave request has been Approved by <b>{1}</b>. Kindly review."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{5}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeLeaveRequestAPPSendToAdmin =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " A leave request has been Approved by <b>{1}</b>. Kindly review."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{5}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeLeaveRequestREJ =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that your leave request has been rejected by your Manager <b>{1}</b>."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{0}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeLeaveRequestREJSendToHR =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + "  A leave request has been rejected by <b>{1}</b>. Kindly review."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{5}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String EmployeeLeaveRequestREJSendToAdmin =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " A leave request has been rejected by <b>{1}</b>. Kindly review."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{5}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        //* Approve & Reject By Admin *//

        private static String APPByAdminSendTOEMP =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that your leave request has been approved by <b>Admin</b>."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{0}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String APPByAdminSendToHR =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " A leave request has been Approved by <b>Admin</b>. Kindly review."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{5}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String APPByAdminSendToTeamManger =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " A leave request has been Approved by <b>Admin</b>. Kindly review."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{5}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String APPByAdminREJSendToEmp =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " This mail is to inform that your leave request has been rejected by <b>Admin</b>."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{0}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String APPByAdminREJSendToHR =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " A leave request has been rejected by <b>Admin</b>. Kindly review."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{5}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";

        private static String APPByAdminREJSendToTeamManager =
            " <html> "
            + " <body> "
            + " <div style='border-style: solid; border-color: #999999;width:450px;height:250px;background-color: #00D2D2'> "
            + " <table align='center'> "
            + " <br/>"
            + " <br/>"
            + " Dear <b>{0}</b>, "
            + " <br/> <br/> "
            + " A leave request has been rejected by <b>Admin</b>. Kindly review."
            + " <br/>"
            + " <br/>"
            + " <b>Leave Request details:</b>"
                + " <br/>"
            + " <ul> "
            + " <li type='square'><font color='blue'>Employee Name : </font> <b>{5}</b></li> "
                + " <br/> "
            //+ " <li type='square'><font color='blue'>Designation : </font> <b>{2}</b></li> "
            //    + " <br/> "
            + " <li type='square'><font color='blue'>Team : </font> <b>{3}</b></li> "
            + " </ul>"
                + " <br/> "
            + " <table border='3'> "
                + "<tr style='background-color: #808080; color: #FFFFFF;'> "
                    + " <td> From Date </td> "
                    + " <td> To Date </td> "
                    + " <td> Day Count</td> "
                    + " {4} "
                + "</tr> "
            + " </table> "
                + " <br/> "
            + "Please access the application by clicking on 192.168.1.2/altiohr "
                + " <br/> "
                + " <br/> "
            + " Regards,"
                + " <br/> "
            + " Altiostar HR"
            + " <br/>"
            + " <br/>"
            + " </table> "
            + " </div> "
            + " </body> "
            + " </html> ";


        String ManagerEmailID = "";
        String ManagerName = "";
        String EMPEmailID = "";
        String EMPName = "";
        String Designation = "";
        String TeameName = "";
        String HtmlText = "";       

        public void LeaveReqNotification(int EmployeeID, DateTime FromDate, DateTime ToDate, int ManagerID, String Reason, double DaysCount, int TeamID)
        {            
            //BaseMaster_EmployeeExtened Details = new Master_EmployeesBusinessObject().GetManagerNotificationDetails(ManagerID);
            //ManagerEmailID = Details.EmailID;
            //ManagerName = Details.ManagerName;

          

            BaseMaster_EmployeeExtened EmpDetails = new Master_EmployeesBusinessObject().GetEmployeeNotificationDetails(EmployeeID);
            EMPEmailID = EmpDetails.EmailID;
            EMPName = EmpDetails.ManagerName;
            TeameName = EmpDetails.TeamName;
            Designation = EmpDetails.Designation;
            //int ManagerID = EmpDetails.EmpID;

            DataTable TeamManager = new ExitManagementBusinessObject().GetManagerEmailIDs(ManagerID);
            ManagerEmailID = TeamManager.Rows[0]["ManagerEmailID"].ToString();
            ManagerName = TeamManager.Rows[0]["ManagerName"].ToString();

            DataTable HRDetails = new ExitManagementBusinessObject().GetHrEmailIDs();
            String HREmailID = HRDetails.Rows[0]["HREmailID"].ToString();
            String HRName = HRDetails.Rows[0]["HRName"].ToString();
            String HRRole = HRDetails.Rows[0]["Role"].ToString();

            DataTable AdminDetails = new ExitManagementBusinessObject().GetAdminEmailIDs();
            String AdminEmailID = AdminDetails.Rows[0]["AdminEmailID"].ToString();
            String AdminName = AdminDetails.Rows[0]["AdminName"].ToString();
            String AdminRole = AdminDetails.Rows[0]["Role"].ToString();
            
            HtmlText = HtmlText + "<tr><td>" + FromDate.ToString("dd/MM/yyyy") + "</td><td>" + ToDate.ToString("dd/MM/yyyy") + "</td><td>" + DaysCount + "</td>";

            MailContent Mail = new MailContent();
            Mail.AddToAddress(ManagerEmailID);
            Mail.Subject = "Leave Request";
            Mail.Body = String.Format(EmployeeLeaveRequest, ManagerName, EMPName, Designation, TeameName, HtmlText);
            IRCAMailHandler.SendMail(Mail);

            if (HRRole == "HR")
            {
                MailContent Mail1 = new MailContent();
                Mail1.AddToAddress(HREmailID);
                Mail1.Subject = "Leave Request";
                Mail1.Body = String.Format(EmployeeLeaveRequestSendToHR, HRName, EMPName, Designation, TeameName, HtmlText);
                IRCAMailHandler.SendMail(Mail1);
            }
            if (AdminRole == "Administrator")
            {
                MailContent Mail2 = new MailContent();
                Mail2.AddToAddress(AdminEmailID);
                Mail2.Subject = "Leave Request";
                Mail2.Body = String.Format(EmployeeLeaveRequestSendToAdmin, AdminName, EMPName, Designation, TeameName, HtmlText);
                IRCAMailHandler.SendMail(Mail2);
            }
        }

        public void LeaveReqStatus(int LeaveRequestID, int EmployeeID, String Comments, String Status, int ManagerID, int TeamID)
        {
            EmployeeLeaveExtened Details = new Master_EmployeesBusinessObject().GetManagerNotificationDetails(LeaveRequestID);
            int EmpID = Details.EmpID;

            DataTable TeamManager = new ExitManagementBusinessObject().GetManagerEmailIDs(Details.ManagerID);
            ManagerEmailID = TeamManager.Rows[0]["ManagerEmailID"].ToString();
            ManagerName = TeamManager.Rows[0]["ManagerName"].ToString();

            DataTable HRDetails = new ExitManagementBusinessObject().GetHrEmailIDs();
            String HREmailID = HRDetails.Rows[0]["HREmailID"].ToString();
            String HRName = HRDetails.Rows[0]["HRName"].ToString();
            String HRRole = HRDetails.Rows[0]["Role"].ToString();

            DataTable AdminDetails = new ExitManagementBusinessObject().GetAdminEmailIDs();
            String AdminEmailID = AdminDetails.Rows[0]["AdminEmailID"].ToString();
            String AdminName = AdminDetails.Rows[0]["AdminName"].ToString();
            String AdminRole = AdminDetails.Rows[0]["Role"].ToString();

            DataTable RoleDetails = new ExitManagementBusinessObject().GetRoleEmailANDName(EmployeeID);
            String roleName = RoleDetails.Rows[0]["Role"].ToString();

            BaseMaster_EmployeeExtened EmpDetails = new Master_EmployeesBusinessObject().GetEmployeeNotificationDetails(EmpID);
            EMPEmailID = EmpDetails.EmailID;
            EMPName = EmpDetails.ManagerName;
            TeameName = EmpDetails.TeamName;
            Designation = EmpDetails.Designation;            
            Leave_Request LR = new Leave_RequestBusinessObject().GetDate(EmpID,Status);
            String EMPFromDate = LR.FromDate.ToString("dd/MM/yyyy");
            String EMPToDate = LR.ToDate.ToString("dd/MM/yyyy");
            double EmpDaysCount = LR.DaysCount;
            String EMPHtmlText = "";
            EMPHtmlText = EMPHtmlText + "<tr><td>" + EMPFromDate + "</td><td>" + EMPToDate + "</td><td>" + EmpDaysCount + "</td>";
            if (roleName == "Administrator" && Status == "APP")
            {
                MailContent Mail = new MailContent();
                Mail.AddToAddress(EMPEmailID);
                Mail.Subject = "Leave Approved";
                Mail.Body = String.Format(APPByAdminSendTOEMP, EMPName, AdminName, Designation, TeameName, EMPHtmlText);
                IRCAMailHandler.SendMail(Mail);

                if (HRRole == "HR")
                {
                    MailContent Mail1 = new MailContent();
                    Mail1.AddToAddress(HREmailID);
                    Mail1.Subject = "Leave Approved";
                    Mail1.Body = String.Format(APPByAdminSendToHR, HRName, AdminName, Designation, TeameName, EMPHtmlText,EMPName);
                    IRCAMailHandler.SendMail(Mail1);
                }
                MailContent Mail2 = new MailContent();
                Mail2.AddToAddress(ManagerEmailID);
                Mail2.Subject = "Leave Approved";
                Mail2.Body = String.Format(APPByAdminSendToTeamManger, ManagerName, AdminName, Designation, TeameName, EMPHtmlText, EMPName);
                IRCAMailHandler.SendMail(Mail2);

            }
            else if (Status == "APP")
            {
                MailContent Mail = new MailContent();
                Mail.AddToAddress(EMPEmailID);
                Mail.Subject = "Leave Approved";
                Mail.Body = String.Format(EmployeeLeaveRequestAPP, EMPName, ManagerName, Designation, TeameName, EMPHtmlText);
                IRCAMailHandler.SendMail(Mail);

                if (HRRole == "HR")
                {
                    MailContent Mail1 = new MailContent();
                    Mail1.AddToAddress(HREmailID);
                    Mail1.Subject = "Leave Approved";
                    Mail1.Body = String.Format(EmployeeLeaveRequestAPPSendToHR, HRName, ManagerName, Designation,TeameName, EMPHtmlText, EMPName);
                    IRCAMailHandler.SendMail(Mail1);
                }
                if (AdminRole == "Administrator")
                {
                    MailContent Mail2 = new MailContent();
                    Mail2.AddToAddress(AdminEmailID);
                    Mail2.Subject = "Leave Approved";
                    Mail2.Body = String.Format(EmployeeLeaveRequestAPPSendToAdmin, AdminName, ManagerName, Designation,TeameName, EMPHtmlText, EMPName);
                    IRCAMailHandler.SendMail(Mail2);
                }
            }
            if (roleName == "Administrator" && Status == "REJ")
            {
                MailContent Mail = new MailContent();
                Mail.AddToAddress(EMPEmailID);
                Mail.Subject = "Leave Rejected";
                Mail.Body = String.Format(APPByAdminREJSendToEmp, EMPName, AdminName, Designation, TeameName, EMPHtmlText);
                IRCAMailHandler.SendMail(Mail);

                if (HRRole == "HR")
                {
                    MailContent Mail1 = new MailContent();
                    Mail1.AddToAddress(HREmailID);
                    Mail1.Subject = "Leave Rejected";
                    Mail1.Body = String.Format(APPByAdminREJSendToHR, HRName, AdminName, Designation, TeameName,EMPHtmlText, EMPName);
                    IRCAMailHandler.SendMail(Mail1);
                }
                MailContent Mail3 = new MailContent();
                Mail3.AddToAddress(ManagerEmailID);
                Mail3.Subject = "Leave Rejected";
                Mail3.Body = String.Format(APPByAdminREJSendToTeamManager, ManagerName, AdminName, Designation, TeameName, EMPHtmlText, EMPName);
                IRCAMailHandler.SendMail(Mail3);
            }
            else if (Status == "REJ")
            {
                MailContent Mail = new MailContent();
                Mail.AddToAddress(EMPEmailID);
                Mail.Subject = "Leave Rejected";
                Mail.Body = String.Format(EmployeeLeaveRequestREJ, EMPName, ManagerName, Designation, TeameName, EMPHtmlText);
                IRCAMailHandler.SendMail(Mail);

                if (HRRole == "HR")
                {
                    MailContent Mail1 = new MailContent();
                    Mail1.AddToAddress(HREmailID);
                    Mail1.Subject = "Leave Rejected";
                    Mail1.Body = String.Format(EmployeeLeaveRequestREJSendToHR, HRName, ManagerName, Designation,TeameName, EMPHtmlText, EMPName);
                    IRCAMailHandler.SendMail(Mail1);
                }
                if (AdminRole == "Administrator")
                {
                    MailContent Mail5 = new MailContent();
                    Mail5.AddToAddress(AdminEmailID);
                    Mail5.Subject = "Leave Rejected";
                    Mail5.Body = String.Format(EmployeeLeaveRequestREJSendToAdmin, AdminName, ManagerName, Designation,TeameName, EMPHtmlText, EMPName);
                    IRCAMailHandler.SendMail(Mail5);
                }
            }
            
        }
    }
}

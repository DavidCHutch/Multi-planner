using System;
using System.Collections.Generic;
using System.Text;

namespace Multi_Planner.DataModel.ViewModels
{
    public class ResponseViewModel
    {
        public bool success { get; set; }
        public string message { get; set; }

        public static ResponseViewModel GetErrorModel(string msg = "") { return new ResponseViewModel() { success = false, message = msg }; }
        public static ResponseViewModel GetSuccessModel(string msg = "") { return new ResponseViewModel() { success = true, message = msg }; }
    }
}

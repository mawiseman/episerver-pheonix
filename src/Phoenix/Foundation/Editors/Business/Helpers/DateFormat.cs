using System.Collections.Generic;

namespace Foundation.Editors.Business.Helpers
{
    public static class DateFormat
    {

        public static void AddDateFormatConstraints(Dictionary<string, object> constraints)
        {
            // TODO: This could probably be enhanced to...
            //  - Read the desired fromat from config so code changes are required per client
            //  - auto load patterns based on logged in users locale

            if (constraints == null)
                constraints = new Dictionary<string, object>();

            constraints.Add("datePattern", "dd/MM/yyyy");
            constraints.Add("locale", "en");

            // this only sets 24 hours time in the text box... not the date time selector
            //constraints.Add("timePattern", "HH:mm"); 
        }
    }
}
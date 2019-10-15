using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using Foundation.Editors.Business.Helpers;
using System;
using System.Collections.Generic;

namespace Foundation.Editors.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(DateTime), UIHint = UIHints.DateOnly)]
    [EditorDescriptorRegistration(TargetType = typeof(DateTime?), UIHint = UIHints.DateOnly)]
    public class DateOnlyEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata,
            IEnumerable<Attribute> attributes)
        {
            // Change the Date selector to Date Only
            ClientEditingClass = "dijit/form/DateTextBox";
            base.ModifyMetadata(metadata, attributes);

            // Set the date format to en-AU
            var constraints = new Dictionary<string, object>() { };
            DateFormat.AddDateFormatConstraints(constraints);
            metadata.EditorConfiguration.Add("constraints", constraints);
        }
    }
}
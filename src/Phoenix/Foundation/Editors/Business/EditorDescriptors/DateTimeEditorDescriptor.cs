using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
using Foundation.Editors.Business.Helpers;
using System;
using System.Collections.Generic;

namespace Foundation.Editors.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(DateTime))]
    [EditorDescriptorRegistration(TargetType = typeof(DateTime?))]
    public class DateTimeEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata,
            IEnumerable<Attribute> attributes)
        {
            // Set the date format to en-AU
            var constraints = new Dictionary<string, object>() { };
            DateFormat.AddDateFormatConstraints(constraints);
            metadata.EditorConfiguration.Add("constraints", constraints);
        }
    }
}
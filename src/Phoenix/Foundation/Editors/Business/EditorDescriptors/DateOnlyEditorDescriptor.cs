using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;
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
            ClientEditingClass = "dijit/form/DateTextBox";
            base.ModifyMetadata(metadata, attributes);
        }
    }
}
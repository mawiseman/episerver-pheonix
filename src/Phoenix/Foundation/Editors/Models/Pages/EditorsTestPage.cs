using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Editors.Models.Pages
{

    /// <summary>
    /// This page can be use to test all the avaliable editors in this feature.
    /// </summary>
    [ContentType(DisplayName = "Editors Test Page",
        GUID = "38221CDC-8719-418F-845A-E59B2CCDCB48")]
    public class EditorsTestPage : PageData
    {
        #region Dates

        const string DatesTab = "Dates";

        [CultureSpecific]
        [Display(
            Name = "Date Time (OOTB)",
            Description = "This is the default DateTime field",
            GroupName = DatesTab,
            Order = 1)]
        public virtual DateTime DateTime { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Date Only",
            GroupName = DatesTab,
            Order = 2)]
        [UIHint(UIHints.DateOnly)]
        public virtual DateTime DateOnly { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Date Only (nullable)",
            GroupName = DatesTab,
            Order = 3)]
        [UIHint(UIHints.DateOnly)]
        public virtual DateTime? DateOnlyNullable { get; set; }

        #endregion
    }
}
﻿using System.ComponentModel;
using System.Windows.Forms;
using System;

namespace WinForms.Tiles
{
    internal static class ControlExtension
    {
        public static bool IsAncestorSiteInDesignMode(this Control control) =>
            GetSitedParentSite(control) is ISite parentSite ? parentSite.DesignMode : false;

        private static ISite? GetSitedParentSite(Control control)
        {
            if (control is null)
            {
                throw new ArgumentNullException(nameof(control));
            }

            return (control.Site is not null && control.Site.DesignMode) || control.Parent is null ?
                control.Site : GetSitedParentSite(control.Parent);
        }
    }
}

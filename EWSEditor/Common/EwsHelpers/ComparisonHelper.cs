namespace EWSEditor.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    public class ComparisonHelper
    {
        private ComparisonHelper()
        {
        }

        /// <summary>
        /// Determine if two FolderPermissions objects are equal
        /// </summary>
        /// <param name="perm1">First FolderPermission to compare</param>
        /// <param name="perm2">Second FolderPermission to compare</param>
        /// <returns>Returns true if objects are equal</returns>
        public static bool IsEqual(FolderPermission perm1, FolderPermission perm2)
        {
            // If any one of these properties are not equal then the permissions
            // are not equal...
            if (perm1.CanCreateItems != perm2.CanCreateItems)
            {
                return false;
            }

            if (perm1.CanCreateSubFolders != perm2.CanCreateSubFolders)
            {
                return false;
            }

            if (perm1.DeleteItems != perm2.DeleteItems)
            {
                return false;
            }

            if (perm1.DisplayPermissionLevel != perm2.DisplayPermissionLevel)
            {
                return false;
            }

            if (perm1.EditItems != perm2.EditItems)
            {
                return false;
            }

            if (perm1.IsFolderContact != perm2.IsFolderContact)
            {
                return false;
            }

            if (perm1.IsFolderOwner != perm2.IsFolderOwner)
            {
                return false;
            }

            if (perm1.IsFolderVisible != perm2.IsFolderVisible)
            {
                return false;
            }

            if (perm1.PermissionLevel != perm2.PermissionLevel)
            {
                return false;
            }

            if (perm1.ReadItems != perm2.ReadItems)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Determine if two OofSettings objects are equal
        /// </summary>
        /// <param name="oof1">First OofSettings to compare</param>
        /// <param name="oof2">Second OofSettings to compare</param>
        /// <returns>Returns true if objects are equal, false is not</returns>
        public static bool IsEqual(OofSettings oof1, OofSettings oof2)
        {
            // If both OofSettings are null they are equal and we
            // don't need to look any deeper
            if (oof1 == null && oof2 == null)
            {
                return true;
            }

            // If only one of the OofSettings is null
            if (oof2 == null ^ oof1 == null)
            {
                return false;
            }

            // If only one of the Duration properties is null 
            if (oof1.Duration == null ^ oof2.Duration == null)
            {
                return false;
            }

            // If Durations are set but are different
            if ((oof1.Duration != null && oof2.Duration != null) &&
                (!DateTime.Equals(oof1.Duration.StartTime, oof2.Duration.StartTime) ||
                !DateTime.Equals(oof1.Duration.EndTime, oof2.Duration.EndTime)))
            {
                return false;
            }

            if (oof1.ExternalAudience != oof2.ExternalAudience)
            {
                return false;
            }

            // If only one of the ExtenalReply properties is null
            if (oof1.ExternalReply == null ^ oof2.ExternalReply == null)
            {
                return false;
            }

            // If ExternalReply properties are set but are different
            if (((oof1.ExternalReply != null) && (oof2.ExternalReply != null)) &&
                (!String.Equals(oof1.ExternalReply.Culture, oof2.ExternalReply.Culture) ||
                !String.Equals(oof1.ExternalReply.Message, oof2.ExternalReply.Message)))
            {
                return false;
            }

            // If only one of the InternalReply properties is null
            if (oof1.InternalReply == null ^ oof2.InternalReply == null)
            {
                return false;
            }

            // If InternalReply properties are set but are different
            if (((oof1.InternalReply != null) && (oof2.InternalReply != null)) &&
                (!String.Equals(oof1.InternalReply.Culture, oof2.InternalReply.Culture) ||
                !String.Equals(oof1.InternalReply.Message, oof2.InternalReply.Message)))
            {
                return false;
            }

            if (oof1.State != oof2.State)
            {
                return false;
            }

            // If we got here they must be equal
            return true;
        }
    }
}

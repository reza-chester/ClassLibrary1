using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserPropertiesAD
{
    public static class FillProperteis
    {
        
       
        public static UserProperties GetProperties(string Username)
        {
            var ctx = new PrincipalContext(ContextType.Domain);

            var userAd = UserPrincipal.FindByIdentity(ctx, Username);
            if (userAd != null)
            {
                UserProperties obj = new UserProperties();
                DirectoryEntry de = userAd.GetUnderlyingObject() as DirectoryEntry;
                foreach (string PropertyName in de.Properties.PropertyNames)
                {
                    switch (PropertyName)
                    {
                       case "givenName":
                            obj.FirstName = de.Properties["givenName"].Value.ToString();
                            break;
                       case "sn":
                            obj.LastName = de.Properties["sn"].Value.ToString();
                            break;
                       case "employeeID":
                            obj.EmployeeID = de.Properties["employeeID"].Value.ToString();
                            break;
                       case "extensionAttribute13":
                            obj.BirthdayDate = de.Properties["extensionAttribute13"].Value.ToString();
                            break;
                       case "physicalDeliveryOfficeName":
                            obj.OfficeName = de.Properties["physicalDeliveryOfficeName"].Value.ToString();
                            break;
                       case "department":
                            obj.Department = de.Properties["department"].Value.ToString();
                            break;
                       case "extensionAttribute15":
                            obj.Level = de.Properties["extensionAttribute15"].Value.ToString();
                            break;
                       case "mobile":
                            obj.Mobile = de.Properties["mobile"].Value.ToString();
                            break;
                       case "title":
                            obj.WorkTitle = de.Properties["title"].Value.ToString();
                            break;
                       case "displayName":
                            obj.DisplayName = de.Properties["displayName"].Value.ToString();
                            break;
                       case "l":
                            obj.Location = de.Properties["l"].Value.ToString();
                            break;
                      case "extensionAttribute14":
                            obj.Partition = de.Properties["extensionAttribute14"].Value.ToString();
                            break;
                      case "description":
                            obj.SubTitle = de.Properties["description"].Value.ToString();
                            break;
                      case "manager":
                            UserPrincipal? M = UserPrincipal.FindByIdentity(ctx, de.Properties["manager"].Value?.ToString());
                            obj.Manager = (M.Name.IndexOf("-") > 0) ? M.Name.Substring(0, M.Name.IndexOf("-") - 1) : M.Name;
                            break;
                        case "extensionAttribute8":
                            obj.StartDate = de.Properties["extensionAttribute8"].Value.ToString();
                            break;
                        case "thumbnailPhoto":
                            byte[] _photo = de.Properties["thumbnailPhoto"].Value as byte[];
                            obj.PhotoByte = _photo;
                            obj.PhotoBase64 = (_photo != null) ? $"data:image/png;base64,{Convert.ToBase64String(_photo, 0, _photo.Length)}" : null;
                            break;
                      
                    }
                }
                return obj;
            }
            else
                return null;
        }
    }
}

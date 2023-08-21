using System;
using PIDevGuru.PIWebApiClient.Models;

namespace PIDevGuru.PIWebApiClient.WebID
{
    public class WebIdGenerator
    {

        public string GenerateWebIdByPath(string path, Type type, Type ownerType = null)
        {
            ValidateTypeAndOwnerType(type, ownerType);
            string marker = GetMarker(type);
            string ownerMarker = GetOwnerMarker(ownerType);

            if (path.Substring(0, 2) == "\\\\")
            {
                path = path.Substring(2);
            }
            string encodedPath = Encode(path.ToUpperInvariant());
            return string.Format("P1{0}{1}{2}", marker, ownerMarker, encodedPath);
        }

        private void ValidateTypeAndOwnerType(Type type, Type ownerType)
        {
            if (type == typeof(PWAAttribute))
            {
                if ((ownerType != typeof(PWAElement)) && (ownerType != typeof(PWAEventFrame)))
                {
                    throw new WebIdException("Attribte owner type must be a Element or a EventFrame.");
                }
            }
            else if (type == typeof(PWAAttributeTemplate))
            {
                if ((ownerType != typeof(PWAElementTemplate)))
                {
                    throw new WebIdException("AttributeTemplate owner type must be a ElementTemplate.");
                }
            }
            else if ((type == typeof(PWAEnumerationSet)) || (type == typeof(PWAEnumerationValue)))
            {
                if ((ownerType != typeof(PWADataServer)) && (ownerType != typeof(PWAAssetServer)))
                {
                    throw new WebIdException("EnumerationSet and  EnumerationValue owner type must be a DataServer or AssetServer.");
                }
            }
            else if (type == typeof(PWATimeRule))
            {
                if ((ownerType != typeof(PWAAnalysis)) && (ownerType != typeof(PWAAnalysisTemplate)))
                {
                    throw new WebIdException("TimeRule owner type must be a Analysis and AnalysisTemplate.");
                }
            }
        }

        private string GetOwnerMarker(Type ownerType)
        {
            string markerOwner = string.Empty;
            if (ownerType == null)
            {
                return markerOwner;
            }

            if (ownerType == typeof(PWAAssetServer))
            {
                markerOwner = "R";
            }
            else if (ownerType == typeof(PWADataServer))
            {
                markerOwner = "D";
            }
            else if (ownerType == typeof(PWAAnalysis))
            {
                markerOwner = "X";
            }
            else if (ownerType == typeof(PWAAnalysisTemplate))
            {
                markerOwner = "T";
            }
            else if (ownerType == typeof(PWAElement))
            {
                markerOwner = "E";
            }
            if (ownerType == typeof(PWAElementTemplate))
            {
                markerOwner = "E";
            }
            else if (ownerType == typeof(PWAEventFrame))
            {
                markerOwner = "F";
            }
            return markerOwner;
        }

        private string GetMarker(Type type)
        {
            string marker = string.Empty;
            if (type == typeof(PWAAnalysis))
            {
                marker = "Xs";
            }
            else if (type == typeof(PWAAnalysisCategory))
            {
                marker = "XC";
            }
            else if (type == typeof(PWAAnalysisTemplate))
            {
                marker = "XT";
            }
            else if (type == typeof(PWAAnalysisRule))
            {
                marker = "XR";
            }
            else if (type == typeof(PWAAnalysisRulePlugIn))
            {
                marker = "XP";
            }
            else if (type == typeof(PWAAttribute))
            {
                marker = "Ab";
            }
            else if (type == typeof(PWAAttributeCategory))
            {
                marker = "AC";
            }
            else if (type == typeof(PWAAttributeTemplate))
            {
                marker = "AT";
            }
            else if (type == typeof(PWAAssetDatabase))
            {
                marker = "RD";
            }
            else if (type == typeof(PWAAssetServer))
            {
                marker = "RS";
            }
            else if (type == typeof(PWAElement))
            {
                marker = "Em";
            }
            else if (type == typeof(PWAElementCategory))
            {
                marker = "EC";
            }
            else if (type == typeof(PWAElementTemplate))
            {
                marker = "ET";
            }
            else if (type == typeof(PWAEnumerationSet))
            {
                marker = "MS";
            }
            else if (type == typeof(PWAEnumerationValue))
            {
                marker = "MV";
            }
            else if (type == typeof(PWAEventFrame))
            {
                marker = "Fm";
            }
            else if (type == typeof(PWATimeRule))
            {
                marker = "TR";
            }
            else if (type == typeof(PWATimeRulePlugIn))
            {
                marker = "TP";
            }
            else if (type == typeof(PWASecurityIdentity))
            {
                marker = "SI";
            }
            else if (type == typeof(PWASecurityMapping))
            {
                marker = "SM";
            }
            else if (type == typeof(PWATable))
            {
                marker = "Bl";
            }
            else if (type == typeof(PWATableCategory))
            {
                marker = "BC";
            }
            else if (type == typeof(PWAPoint))
            {
                marker = "DP";
            }
            else if (type == typeof(PWADataServer))
            {
                marker = "DS";
            }
            else if (type == typeof(PWAUnit))
            {
                marker = "Ut";
            }
            else if (type == typeof(PWAUnitClass))
            {
                marker = "UC";
            }
            if (string.IsNullOrEmpty(marker) == true)
            {
                throw new WebIdException("Invalid object type.");
            }
            return marker;
        }

        internal static string Encode(string value)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(value.ToUpperInvariant());
            return Encode(bytes);
        }

        internal static string Encode(byte[] value)
        {
            string encoded = System.Convert.ToBase64String(value);
            return encoded.TrimEnd(new char[] { '=' }).Replace('+', '-').Replace('/', '_');
        }
    }
}

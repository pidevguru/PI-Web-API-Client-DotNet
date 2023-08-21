using PIDevGuru.PIWebApiClient.Models;
using System;
using System.Text;

namespace PIDevGuru.PIWebApiClient.WebID
{
    public class WebIdInfo
    {
        private enum WebIdStringType { OneGuid, TwoGuids, ThreeGuids }
        public Type ObjectType { get; private set; }
        public Type OwnerType { get; private set; }
        public Guid ServerID { get; private set; }
        public Guid ObjectID { get; private set; }
        public Guid OwnerID { get; private set; }
        public int PointID { get; private set; }
        public string Path { get; private set; }
        public WebIdType WebIdType { get; private set; }
        public int Version { get; private set; }
        public string Marker { get; private set; }

        internal WebIdInfo(string webId)
        {
            WebIdType = GetWebIdType(webId);
            if ((WebIdType == WebIdType.DefaultIDOnly) || (WebIdType == WebIdType.LocalIDOnly))
            {
                throw new WebIdException("This library is not compatible with DefaultIDOnly or LocalIDOnly. Use Full, PathOnly or IDOnly instead.");
            }
            Version = Convert.ToInt32(webId.Substring(1, 1));
            if (Version == 0)
            {
                throw new WebIdException("This tool is compatible with Web ID 2.0 only. The second character of the Web ID must be 1.");
            }

            ProcessType(webId);
            ProcessGuidsAndPaths(webId);
        }

        private WebIdType GetWebIdType(string webId)
        {
            string webIdTypeLetter = webId.Substring(0, 1);
            if (webIdTypeLetter == "F")
            {
                return WebIdType.Full;
            }
            else if (webIdTypeLetter == "I")
            {
                return WebIdType.IDOnly;
            }
            else if (webIdTypeLetter == "P")
            {
                return WebIdType.PathOnly;
            }
            else if (webIdTypeLetter == "L")
            {
                return WebIdType.LocalIDOnly;
            }
            else if (webIdTypeLetter == "D")
            {
                return WebIdType.DefaultIDOnly;
            }
            throw new WebIdException("Incorrect Web ID type (first letter).");
        }

        private void ProcessType(string webId)
        {
            Marker = webId.Substring(2, 2);
            if (Marker == "Xs")
            {
                ObjectType = typeof(PWAAnalysis);
            }
            else if (Marker == "XC")
            {
                ObjectType = typeof(PWAAnalysisCategory);
            }
            else if (Marker == "XT")
            {
                ObjectType = typeof(PWAAnalysisTemplate);
            }
            else if (Marker == "XR")
            {
                ObjectType = typeof(PWAAnalysisRule);
            }
            else if (Marker == "XP")
            {
                ObjectType = typeof(PWAAnalysisRulePlugIn);
            }
            else if (Marker == "Ab")
            {
                ObjectType = typeof(PWAAttribute);
            }
            else if (Marker == "AC")
            {
                ObjectType = typeof(PWAAttributeCategory);
            }
            else if (Marker == "AT")
            {
                ObjectType = typeof(PWAAttributeTemplate);
            }
            else if (Marker == "RD")
            {
                ObjectType = typeof(PWAAssetDatabase);
            }
            else if (Marker == "Em")
            {
                ObjectType = typeof(PWAElement);
            }
            else if (Marker == "EC")
            {
                ObjectType = typeof(PWAElementCategory);
            }
            else if (Marker == "ET")
            {
                ObjectType = typeof(PWAElementTemplate);
            }
            else if (Marker == "MS")
            {
                ObjectType = typeof(PWAEnumerationSet);
            }
            else if (Marker == "MV")
            {
                ObjectType = typeof(PWAEnumerationValue);
            }
            else if (Marker == "Fm")
            {
                ObjectType = typeof(PWAEventFrame);
            }
            else if (Marker == "TR")
            {
                ObjectType = typeof(PWATimeRule);
            }
            else if (Marker == "TP")
            {
                ObjectType = typeof(PWATimeRulePlugIn);
            }
            else if (Marker == "SI")
            {
                ObjectType = typeof(PWASecurityIdentity);
            }
            else if (Marker == "SM")
            {
                ObjectType = typeof(PWASecurityMapping);
            }
            else if (Marker == "Bl")
            {
                ObjectType = typeof(PWATable);
            }
            else if (Marker == "BC")
            {
                ObjectType = typeof(PWATableCategory);
            }
            else if (Marker == "DP")
            {
                ObjectType = typeof(PWAPoint);
            }
            else if (Marker == "DS")
            {
                ObjectType = typeof(PWADataServer);
            }
            else if (Marker == "RS")
            {
                ObjectType = typeof(PWAAssetServer);
            }
            else if (Marker == "Ut")
            {
                ObjectType = typeof(PWAUnit);
            }
            else if (Marker == "UC")
            {
                ObjectType = typeof(PWAUnitClass);
            }
        }

        private void ProcessOwnerType(string markerOwner)
        {
            if (markerOwner == "R")
            {
                OwnerType = typeof(PWAAssetServer);
            }
            else if (markerOwner == "D")
            {
                OwnerType = typeof(PWADataServer);
            }
            else if (markerOwner == "X")
            {
                OwnerType = typeof(PWAAnalysis);
            }
            else if (markerOwner == "T")
            {
                OwnerType = typeof(PWAAnalysisTemplate);
            }
            else if (markerOwner == "E")
            {
                OwnerType = typeof(PWAElement);
            }
            else if (markerOwner == "F")
            {
                OwnerType = typeof(PWAEventFrame);
            }
        }

        private void ProcessGuidsAndPaths(string webId)
        {
            if (ObjectType == typeof(PWAAnalysis))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAAnalysisCategory))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAAnalysisTemplate))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAAnalysisRule))
            {
                ProcessGuidsAndPaths(webId, true, WebIdStringType.ThreeGuids, false);
            }
            else if (ObjectType == typeof(PWAAnalysisRulePlugIn))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAAttribute))
            {
                ProcessGuidsAndPaths(webId, true, WebIdStringType.ThreeGuids, false);
            }
            else if (ObjectType == typeof(PWAAttributeCategory))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAAttributeTemplate))
            {
                ProcessGuidsAndPaths(webId, true, WebIdStringType.ThreeGuids, false);
                OwnerType = typeof(PWAElementTemplate);
            }
            else if (ObjectType == typeof(PWAAssetDatabase))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAElement))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAElementCategory))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAElementTemplate))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAEnumerationSet))
            {
                ProcessGuidsAndPaths(webId, true, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAEnumerationValue))
            {
                ProcessGuidsAndPaths(webId, true, WebIdStringType.ThreeGuids, false);
            }
            else if (ObjectType == typeof(PWAEventFrame))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWATimeRule))
            {
                ProcessGuidsAndPaths(webId, true, WebIdStringType.ThreeGuids, false);
            }
            else if (ObjectType == typeof(PWATimeRulePlugIn))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWASecurityIdentity))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWASecurityMapping))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWATable))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWATableCategory))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAPoint))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, true);
            }
            else if (ObjectType == typeof(PWADataServer))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.OneGuid, false);
            }
            else if (ObjectType == typeof(PWAAssetServer))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.OneGuid, false);
            }
            else if (ObjectType == typeof(PWAUnit))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
            else if (ObjectType == typeof(PWAUnitClass))
            {
                ProcessGuidsAndPaths(webId, false, WebIdStringType.TwoGuids, false);
            }
        }



        private void ProcessGuidsAndPaths(string webId, bool hasMarkerOwner, WebIdStringType webIdStringType, bool usePIPoint = false)
        {
            string restWebId = webId.Substring(4);

            if (hasMarkerOwner == true)
            {
                string markerOwner = restWebId.Substring(0, 1);
                ProcessOwnerType(markerOwner);
                restWebId = restWebId.Substring(1);
            }

            if ((WebIdType == WebIdType.Full) || (WebIdType == WebIdType.IDOnly))
            {
                string encodedServerID = restWebId.Substring(0, 22);
                ServerID = DecodeGUID(encodedServerID);
                restWebId = restWebId.Substring(22);

                if (webIdStringType == WebIdStringType.ThreeGuids)
                {
                    string encodedOwnerID = restWebId.Substring(0, 22);
                    OwnerID = DecodeGUID(encodedOwnerID);
                    restWebId = restWebId.Substring(22);
                }
                if ((webIdStringType == WebIdStringType.ThreeGuids) ||
                    (webIdStringType == WebIdStringType.TwoGuids))
                {

                    if (usePIPoint == false)
                    {
                        string encodedObjectID = restWebId.Substring(0, 22);
                        ObjectID = DecodeGUID(encodedObjectID);
                        restWebId = restWebId.Substring(22);
                    }
                    else
                    {
                        string encodedObjectID = restWebId.Substring(0, 6);
                        PointID = DecodeInt(encodedObjectID);
                        restWebId = restWebId.Substring(6);
                    }

                }
            }

            if ((WebIdType == WebIdType.Full) || (WebIdType == WebIdType.PathOnly))
            {
                string encodedPath = restWebId;
                Path = DecodeString(encodedPath);
            }
        }

        internal static byte[] Decode(string value)
        {
            //Base 64 strings are in multiples of 4 bytes long.  
            //This restores the = sign padding and changes the Uri-safe chars with the Base64 requirement  
            StringBuilder decodestring = new StringBuilder(value.Replace('-', '+').Replace('_', '/'));
            int padneeded = (4 - (value.Length % 4)) % 4;

            for (int i = 0; i < padneeded; i++)
            {
                decodestring.Append('=');
            }

            byte[] bytes = System.Convert.FromBase64String(decodestring.ToString());
            return bytes;
        }

        internal static string DecodeString(string value)
        {
            return Encoding.UTF8.GetString(Decode(value));
        }

        internal static int DecodeInt(string input)
        {
            byte[] bytes = Decode(input);
            if (!BitConverter.IsLittleEndian)
            {
                Array.Reverse(bytes);
            }

            return BitConverter.ToInt32(bytes, 0);
        }

        internal static Guid DecodeGUID(string value)
        {
            byte[] guid = Decode(value);
            return new Guid(guid);
        }

    }
}

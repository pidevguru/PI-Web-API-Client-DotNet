using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using PIDevGuru.PIWebApiClient.Client;
using PIDevGuru.PIWebApiClient.Controllers;

namespace PIDevGuru.PIWebApiClient
{
    public class PIWebAPI
    {
        public string BaseUrl { get; private set; }

        private HttpClient httpClient;

        public PIWebAPI(string baseUrl)
        {
            BaseUrl = baseUrl;
            SetKerberosAuth();
        }

        public void SetKerberosAuth()
        {
            var handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            httpClient = new HttpClient(handler);
        }

        public void SetBasicAuth(string username, string password)
        {
            var handler = new HttpClientHandler();
            var byteArray = Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password));
            httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Add("X-Requested-With", "PIWebApiClient");
        }
        private HttpApiClient GetHttpApiClient(bool noCacheHeaderCompatible)
        {
            return new HttpApiClient(httpClient, BaseUrl, noCacheHeaderCompatible);
        }


        public AnalysisControllerClient Analysis
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AnalysisControllerClient(httpApiClient);
            }
        }

        public AnalysisCategoryControllerClient AnalysisCategory
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AnalysisCategoryControllerClient(httpApiClient);
            }
        }

        public AnalysisRulePlugInControllerClient AnalysisRulePlugIn
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AnalysisRulePlugInControllerClient(httpApiClient);
            }
        }

        public AnalysisRuleControllerClient AnalysisRule
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AnalysisRuleControllerClient(httpApiClient);
            }
        }

        public AnalysisTemplateControllerClient AnalysisTemplate
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AnalysisTemplateControllerClient(httpApiClient);
            }
        }

        public AssetDatabaseControllerClient AssetData
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AssetDatabaseControllerClient(httpApiClient);
            }
        }

        public AssetServerControllerClient AssetServer
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AssetServerControllerClient(httpApiClient);
            }
        }

        public AttributeControllerClient Attribute
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AttributeControllerClient(httpApiClient);
            }
        }

        public AttributeCategoryControllerClient AttributeCategory
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AttributeCategoryControllerClient(httpApiClient);
            }
        }

        public AttributeTemplateControllerClient AttributeTemplate
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AttributeTemplateControllerClient(httpApiClient);
            }
        }

        public AttributeTraitControllerClient AttributeTrait
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new AttributeTraitControllerClient(httpApiClient);
            }
        }

        public BatchControllerClient BatchApi
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new BatchControllerClient(httpApiClient);
            }
        }

        public CalculationControllerClient Calculation
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(false);
                return new CalculationControllerClient(httpApiClient);
            }
        }

        public ConfigurationControllerClient Configuration
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new ConfigurationControllerClient(httpApiClient);
            }
        }

        public DataServerControllerClient DataServer
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new DataServerControllerClient(httpApiClient);
            }
        }

        public ElementControllerClient Element
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new ElementControllerClient(httpApiClient);
            }
        }

        public ElementCategoryControllerClient ElementCategory
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new ElementCategoryControllerClient(httpApiClient);
            }
        }



        public ElementTemplateControllerClient ElementTemplate
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new ElementTemplateControllerClient(httpApiClient);
            }
        }


        public EnumerationSetControllerClient EnumerationSet
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new EnumerationSetControllerClient(httpApiClient);
            }
        }


        public EnumerationValueControllerClient EnumerationValue
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new EnumerationValueControllerClient(httpApiClient);
            }
        }

        public EventFrameControllerClient EventFrame
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new EventFrameControllerClient(httpApiClient);
            }
        }


        public HomeControllerClient Home
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new HomeControllerClient(httpApiClient);
            }
        }


        public PointControllerClient Point
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new PointControllerClient(httpApiClient);
            }
        }



        public SecurityIdentityControllerClient SecurityIdentity
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new SecurityIdentityControllerClient(httpApiClient);
            }
        }

        public SecurityMappingControllerClient SecurityMapping
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new SecurityMappingControllerClient(httpApiClient);
            }
        }

        public StreamControllerClient Stream
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new StreamControllerClient(httpApiClient);
            }
        }

        public StreamSetControllerClient StreamSet
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(false);
                return new StreamSetControllerClient(httpApiClient);
            }
        }


        public SystemControllerClient System
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new SystemControllerClient(httpApiClient);
            }
        }

        public TableControllerClient Table
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new TableControllerClient(httpApiClient);
            }
        }

        public TableCategoryControllerClient TableCategory
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new TableCategoryControllerClient(httpApiClient);
            }
        }

        public TimeRuleControllerClient TimeRule
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new TimeRuleControllerClient(httpApiClient);
            }
        }

        public TimeRulePlugInControllerClient TimeRulePlugIn
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new TimeRulePlugInControllerClient(httpApiClient);
            }
        }

        public UnitControllerClient Unit
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new UnitControllerClient(httpApiClient);
            }
        }
        public UnitClassControllerClient UnitClass
        {
            get
            {
                HttpApiClient httpApiClient = GetHttpApiClient(true);
                return new UnitClassControllerClient(httpApiClient);
            }
        }
    }
}

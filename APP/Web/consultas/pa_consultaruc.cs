using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.consultas {
   public class pa_consultaruc : GXProcedure
   {
      public pa_consultaruc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public pa_consultaruc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( short aP0_STipSCod ,
                           string aP1_SCliCod ,
                           out string aP2_SCliDsc ,
                           out string aP3_SCliAPEP ,
                           out string aP4_SCliAPEM ,
                           out string aP5_SCliNom ,
                           out string aP6_SCliDir ,
                           out string aP7_ErrorMsg )
      {
         this.AV12STipSCod = aP0_STipSCod;
         this.AV13SCliCod = aP1_SCliCod;
         this.AV9SCliDsc = "" ;
         this.AV15SCliAPEP = "" ;
         this.AV16SCliAPEM = "" ;
         this.AV17SCliNom = "" ;
         this.AV10SCliDir = "" ;
         this.AV18ErrorMsg = "" ;
         initialize();
         executePrivate();
         aP2_SCliDsc=this.AV9SCliDsc;
         aP3_SCliAPEP=this.AV15SCliAPEP;
         aP4_SCliAPEM=this.AV16SCliAPEM;
         aP5_SCliNom=this.AV17SCliNom;
         aP6_SCliDir=this.AV10SCliDir;
         aP7_ErrorMsg=this.AV18ErrorMsg;
      }

      public string executeUdp( short aP0_STipSCod ,
                                string aP1_SCliCod ,
                                out string aP2_SCliDsc ,
                                out string aP3_SCliAPEP ,
                                out string aP4_SCliAPEM ,
                                out string aP5_SCliNom ,
                                out string aP6_SCliDir )
      {
         execute(aP0_STipSCod, aP1_SCliCod, out aP2_SCliDsc, out aP3_SCliAPEP, out aP4_SCliAPEM, out aP5_SCliNom, out aP6_SCliDir, out aP7_ErrorMsg);
         return AV18ErrorMsg ;
      }

      public void executeSubmit( short aP0_STipSCod ,
                                 string aP1_SCliCod ,
                                 out string aP2_SCliDsc ,
                                 out string aP3_SCliAPEP ,
                                 out string aP4_SCliAPEM ,
                                 out string aP5_SCliNom ,
                                 out string aP6_SCliDir ,
                                 out string aP7_ErrorMsg )
      {
         pa_consultaruc objpa_consultaruc;
         objpa_consultaruc = new pa_consultaruc();
         objpa_consultaruc.AV12STipSCod = aP0_STipSCod;
         objpa_consultaruc.AV13SCliCod = aP1_SCliCod;
         objpa_consultaruc.AV9SCliDsc = "" ;
         objpa_consultaruc.AV15SCliAPEP = "" ;
         objpa_consultaruc.AV16SCliAPEM = "" ;
         objpa_consultaruc.AV17SCliNom = "" ;
         objpa_consultaruc.AV10SCliDir = "" ;
         objpa_consultaruc.AV18ErrorMsg = "" ;
         objpa_consultaruc.context.SetSubmitInitialConfig(context);
         objpa_consultaruc.initialize();
         Submit( executePrivateCatch,objpa_consultaruc);
         aP2_SCliDsc=this.AV9SCliDsc;
         aP3_SCliAPEP=this.AV15SCliAPEP;
         aP4_SCliAPEM=this.AV16SCliAPEM;
         aP5_SCliNom=this.AV17SCliNom;
         aP6_SCliDir=this.AV10SCliDir;
         aP7_ErrorMsg=this.AV18ErrorMsg;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pa_consultaruc)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HttpClient = new GxHttpClient( context);
         AV9SCliDsc = "";
         AV10SCliDir = "";
         if ( AV12STipSCod == 1 )
         {
            /* Execute user subroutine: 'CONSULTARUC' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( AV12STipSCod == 2 )
         {
            /* Execute user subroutine: 'CONSULTADNI' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CONSULTADNI' Routine */
         returnInSub = false;
         AV8HttpClient.Host = "api.apis.net.pe";
         AV8HttpClient.BaseURL = "/v1/";
         AV8HttpClient.AddHeader("Content-type", "application/json");
         AV8HttpClient.Execute("GET", "dni?numero="+StringUtil.Trim( AV13SCliCod));
         if ( AV8HttpClient.StatusCode == 200 )
         {
            AV14SDTAPIConsultaDNI.FromJSonString(StringUtil.Trim( AV8HttpClient.ToString()), null);
            AV9SCliDsc = StringUtil.Trim( AV14SDTAPIConsultaDNI.gxTpr_Nombre);
            AV15SCliAPEP = StringUtil.Trim( AV14SDTAPIConsultaDNI.gxTpr_Apellidopaterno);
            AV16SCliAPEM = StringUtil.Trim( AV14SDTAPIConsultaDNI.gxTpr_Apellidomaterno);
            AV17SCliNom = StringUtil.Trim( AV14SDTAPIConsultaDNI.gxTpr_Nombres);
         }
         else
         {
            AV18ErrorMsg = "El RUC ingresado no existe o se encuentra mal ingresado";
         }
      }

      protected void S121( )
      {
         /* 'CONSULTARUC' Routine */
         returnInSub = false;
         AV8HttpClient.Host = "api.apis.net.pe";
         AV8HttpClient.BaseURL = "/v1/";
         AV8HttpClient.AddHeader("Content-type", "application/json");
         AV8HttpClient.Execute("GET", "ruc?numero="+StringUtil.Trim( AV13SCliCod));
         if ( AV8HttpClient.StatusCode == 200 )
         {
            AV19SDTAPIConsultaRUC.FromJSonString(StringUtil.Trim( AV8HttpClient.ToString()), null);
            AV9SCliDsc = AV19SDTAPIConsultaRUC.gxTpr_Nombre;
            AV10SCliDir = AV19SDTAPIConsultaRUC.gxTpr_Direccion;
         }
         else
         {
            AV18ErrorMsg = "El RUC ingresado no existe o se encuentra mal ingresado";
         }
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV9SCliDsc = "";
         AV15SCliAPEP = "";
         AV16SCliAPEM = "";
         AV17SCliNom = "";
         AV10SCliDir = "";
         AV18ErrorMsg = "";
         AV8HttpClient = new GxHttpClient( context);
         AV14SDTAPIConsultaDNI = new GeneXus.Programs.consultas.SdtSDT_ConsultaDNI(context);
         AV19SDTAPIConsultaRUC = new GeneXus.Programs.consultas.SdtSDT_ConsultaRuc(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12STipSCod ;
      private bool returnInSub ;
      private string AV13SCliCod ;
      private string AV9SCliDsc ;
      private string AV15SCliAPEP ;
      private string AV16SCliAPEM ;
      private string AV17SCliNom ;
      private string AV10SCliDir ;
      private string AV18ErrorMsg ;
      private string aP2_SCliDsc ;
      private string aP3_SCliAPEP ;
      private string aP4_SCliAPEM ;
      private string aP5_SCliNom ;
      private string aP6_SCliDir ;
      private string aP7_ErrorMsg ;
      private GxHttpClient AV8HttpClient ;
      private GeneXus.Programs.consultas.SdtSDT_ConsultaDNI AV14SDTAPIConsultaDNI ;
      private GeneXus.Programs.consultas.SdtSDT_ConsultaRuc AV19SDTAPIConsultaRUC ;
   }

}

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
namespace GeneXus.Programs.wwpbaseobjects {
   public class saveuserkeyvalue : GXProcedure
   {
      public saveuserkeyvalue( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public saveuserkeyvalue( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( string aP0_UserCustomizationsKey ,
                           string aP1_UserCustomizationsValue )
      {
         this.AV11UserCustomizationsKey = aP0_UserCustomizationsKey;
         this.AV12UserCustomizationsValue = aP1_UserCustomizationsValue;
         initialize();
         executePrivate();
      }

      public void executeSubmit( string aP0_UserCustomizationsKey ,
                                 string aP1_UserCustomizationsValue )
      {
         saveuserkeyvalue objsaveuserkeyvalue;
         objsaveuserkeyvalue = new saveuserkeyvalue();
         objsaveuserkeyvalue.AV11UserCustomizationsKey = aP0_UserCustomizationsKey;
         objsaveuserkeyvalue.AV12UserCustomizationsValue = aP1_UserCustomizationsValue;
         objsaveuserkeyvalue.context.SetSubmitInitialConfig(context);
         objsaveuserkeyvalue.initialize();
         Submit( executePrivateCatch,objsaveuserkeyvalue);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((saveuserkeyvalue)stateInfo).executePrivate();
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12UserCustomizationsValue)) )
         {
            AV10Session.Remove(AV11UserCustomizationsKey);
         }
         else
         {
            AV10Session.Set(AV11UserCustomizationsKey, AV12UserCustomizationsValue);
         }
         this.cleanup();
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
         AV10Session = context.GetSession();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private string AV12UserCustomizationsValue ;
      private string AV11UserCustomizationsKey ;
      private IGxSession AV10Session ;
   }

}

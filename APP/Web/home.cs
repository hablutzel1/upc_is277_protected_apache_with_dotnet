using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class home : GXDataArea
   {
      public home( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS");
      }

      public home( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavHomesampledata__productstatus = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridnotifications") == 0 )
            {
               gxnrGridnotifications_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridnotifications") == 0 )
            {
               gxgrGridnotifications_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_101 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_101"), "."));
         nGXsfl_101_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_101_idx"), "."));
         sGXsfl_101_idx = GetPar( "sGXsfl_101_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
         subGridnotifications_Rows = (int)(NumberUtil.Val( GetPar( "subGridnotifications_Rows"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5HomeSampleData);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7SDTNotificationsData);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, subGridnotifications_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      protected void gxnrGridnotifications_newrow_invoke( )
      {
         nRC_GXsfl_129 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_129"), "."));
         nGXsfl_129_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_129_idx"), "."));
         sGXsfl_129_idx = GetPar( "sGXsfl_129_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridnotifications_newrow( ) ;
         /* End function gxnrGridnotifications_newrow_invoke */
      }

      protected void gxgrGridnotifications_refresh_invoke( )
      {
         subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
         subGridnotifications_Rows = (int)(NumberUtil.Val( GetPar( "subGridnotifications_Rows"), "."));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7SDTNotificationsData);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5HomeSampleData);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridnotifications_refresh( subGrid_Rows, subGridnotifications_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridnotifications_refresh_invoke */
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA092( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START092( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1948100), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1948100), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1948100), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1948100), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1948100), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1948100), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("home.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMESAMPLEDATA", GetSecureSignedToken( "", AV5HomeSampleData, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Homesampledata", AV5HomeSampleData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Homesampledata", AV5HomeSampleData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Homesampledata", GetSecureSignedToken( "", AV5HomeSampleData, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtnotificationsdata", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtnotificationsdata", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Sdtnotificationsdata", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_101", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_101), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_129", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_129), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV14Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV14Elements);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPARAMETERS", AV15Parameters);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPARAMETERS", AV15Parameters);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCLICKDATA", AV16ItemClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCLICKDATA", AV16ItemClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMDOUBLECLICKDATA", AV17ItemDoubleClickData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMDOUBLECLICKDATA", AV17ItemDoubleClickData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDRAGANDDROPDATA", AV18DragAndDropData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDRAGANDDROPDATA", AV18DragAndDropData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERCHANGEDDATA", AV19FilterChangedData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERCHANGEDDATA", AV19FilterChangedData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMEXPANDDATA", AV20ItemExpandData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMEXPANDDATA", AV20ItemExpandData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vITEMCOLLAPSEDATA", AV21ItemCollapseData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vITEMCOLLAPSEDATA", AV21ItemCollapseData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMESAMPLEDATA", GetSecureSignedToken( "", AV5HomeSampleData, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Objectname", StringUtil.RTrim( Utchartstackedbar_Objectname));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Height", StringUtil.RTrim( Utchartstackedbar_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Type", StringUtil.RTrim( Utchartstackedbar_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSTACKEDBAR_Charttype", StringUtil.RTrim( Utchartstackedbar_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Width", StringUtil.RTrim( Dvpanel_tablechart1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Cls", StringUtil.RTrim( Dvpanel_tablechart1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Title", StringUtil.RTrim( Dvpanel_tablechart1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Iconposition", StringUtil.RTrim( Dvpanel_tablechart1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Objectname", StringUtil.RTrim( Utchartcolumnline_Objectname));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Height", StringUtil.RTrim( Utchartcolumnline_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Type", StringUtil.RTrim( Utchartcolumnline_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Charttype", StringUtil.RTrim( Utchartcolumnline_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Width", StringUtil.RTrim( Dvpanel_tablechart2_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart2_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart2_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Cls", StringUtil.RTrim( Dvpanel_tablechart2_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Title", StringUtil.RTrim( Dvpanel_tablechart2_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart2_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart2_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Iconposition", StringUtil.RTrim( Dvpanel_tablechart2_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART2_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart2_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Width", StringUtil.RTrim( Dvpanel_tablenotifications_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Cls", StringUtil.RTrim( Dvpanel_tablenotifications_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Title", StringUtil.RTrim( Dvpanel_tablenotifications_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablenotifications_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Iconposition", StringUtil.RTrim( Dvpanel_tablenotifications_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridnotifications_empowerer_Gridinternalname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE092( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT092( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("home.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Home" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inicio" ;
      }

      protected void WB090( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard1_maintable_Internalname, 1, 0, "px", 0, "px", "TableCardDashboardAdminInfoLight", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard1_content_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard1_value_Internalname, "Card1_Value", "col-sm-3 DashboardNumberAdminLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard1_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Card1_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCard1_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8Card1_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV8Card1_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,19);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard1_value_Jsonclick, 0, "DashboardNumberAdmin", "", "", "", "", 1, edtavCard1_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard1_description_Internalname, "Orders", "", "", lblCard1_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionAdmin", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard1_icon_Internalname, "<i class='AdminDashboardIcon fa fa-shopping-cart'></i>", "", "", lblCard1_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MoreInfoAdminCell", "Center", "top", "", "", "div");
            wb_table1_27_092( true) ;
         }
         else
         {
            wb_table1_27_092( false) ;
         }
         return  ;
      }

      protected void wb_table1_27_092e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard2_maintable_Internalname, 1, 0, "px", 0, "px", "TableCardDashboardAdminSuccess", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard2_content_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard2_value_Internalname, "Card2_Value", "col-sm-3 DashboardNumberAdminLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard2_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9Card2_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCard2_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9Card2_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV9Card2_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard2_value_Jsonclick, 0, "DashboardNumberAdmin", "", "", "", "", 1, edtavCard2_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard2_description_Internalname, "Revenue", "", "", lblCard2_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionAdmin", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard2_icon_Internalname, "<i class='AdminDashboardIcon fa fa-chart-bar'></i>", "", "", lblCard2_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MoreInfoAdminCell", "Center", "top", "", "", "div");
            wb_table2_49_092( true) ;
         }
         else
         {
            wb_table2_49_092( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_092e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard3_maintable_Internalname, 1, 0, "px", 0, "px", "TableCardDashboardAdminWarning", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard3_content_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard3_value_Internalname, "Card3_Value", "col-sm-3 DashboardNumberAdminLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard3_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10Card3_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCard3_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10Card3_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV10Card3_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard3_value_Jsonclick, 0, "DashboardNumberAdmin", "", "", "", "", 1, edtavCard3_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard3_description_Internalname, "Users", "", "", lblCard3_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionAdmin", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard3_icon_Internalname, "<i class='AdminDashboardIcon fa fa-user'></i>", "", "", lblCard3_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MoreInfoAdminCell", "Center", "top", "", "", "div");
            wb_table3_71_092( true) ;
         }
         else
         {
            wb_table3_71_092( false) ;
         }
         return  ;
      }

      protected void wb_table3_71_092e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard4_maintable_Internalname, 1, 0, "px", 0, "px", "TableCardDashboardAdminDanger", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCard4_content_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-10", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCard4_value_Internalname, "Card4_Value", "col-sm-3 DashboardNumberAdminLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'" + sGXsfl_101_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCard4_value_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Card4_Value), 10, 0, ",", "")), StringUtil.LTrim( ((edtavCard4_value_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11Card4_Value), "ZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV11Card4_Value), "ZZ,ZZZ,ZZ9"))), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,85);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCard4_value_Jsonclick, 0, "DashboardNumberAdmin", "", "", "", "", 1, edtavCard4_value_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "KPINumericValue", "right", false, "", "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard4_description_Internalname, "Views", "", "", lblCard4_description_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionAdmin", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard4_icon_Internalname, "<i class='AdminDashboardIcon fa fa-tag'></i>", "", "", lblCard4_icon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MoreInfoAdminCell", "Center", "top", "", "", "div");
            wb_table4_93_092( true) ;
         }
         else
         {
            wb_table4_93_092( false) ;
         }
         return  ;
      }

      protected void wb_table4_93_092e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 col-lg-4 CellMarginTop HasGridEmpowerer", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl101( ) ;
         }
         if ( wbEnd == 101 )
         {
            wbEnd = 0;
            nRC_GXsfl_101 = (int)(nGXsfl_101_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               AV26GXV1 = nGXsfl_101_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 col-lg-8 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart1.SetProperty("Width", Dvpanel_tablechart1_Width);
            ucDvpanel_tablechart1.SetProperty("AutoWidth", Dvpanel_tablechart1_Autowidth);
            ucDvpanel_tablechart1.SetProperty("AutoHeight", Dvpanel_tablechart1_Autoheight);
            ucDvpanel_tablechart1.SetProperty("Cls", Dvpanel_tablechart1_Cls);
            ucDvpanel_tablechart1.SetProperty("Title", Dvpanel_tablechart1_Title);
            ucDvpanel_tablechart1.SetProperty("Collapsible", Dvpanel_tablechart1_Collapsible);
            ucDvpanel_tablechart1.SetProperty("Collapsed", Dvpanel_tablechart1_Collapsed);
            ucDvpanel_tablechart1.SetProperty("ShowCollapseIcon", Dvpanel_tablechart1_Showcollapseicon);
            ucDvpanel_tablechart1.SetProperty("IconPosition", Dvpanel_tablechart1_Iconposition);
            ucDvpanel_tablechart1.SetProperty("AutoScroll", Dvpanel_tablechart1_Autoscroll);
            ucDvpanel_tablechart1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart1_Internalname, "DVPANEL_TABLECHART1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART1Container"+"TableChart1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart1_Internalname, 1, 0, "px", divTablechart1_Height, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartstackedbar.SetProperty("Elements", AV14Elements);
            ucUtchartstackedbar.SetProperty("Parameters", AV15Parameters);
            ucUtchartstackedbar.SetProperty("ObjectName", Utchartstackedbar_Objectname);
            ucUtchartstackedbar.SetProperty("Height", Utchartstackedbar_Height);
            ucUtchartstackedbar.SetProperty("Type", Utchartstackedbar_Type);
            ucUtchartstackedbar.SetProperty("Title", Utchartstackedbar_Title);
            ucUtchartstackedbar.SetProperty("ChartType", Utchartstackedbar_Charttype);
            ucUtchartstackedbar.SetProperty("ItemClickData", AV16ItemClickData);
            ucUtchartstackedbar.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucUtchartstackedbar.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucUtchartstackedbar.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucUtchartstackedbar.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucUtchartstackedbar.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucUtchartstackedbar.Render(context, "queryviewer", Utchartstackedbar_Internalname, "UTCHARTSTACKEDBARContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 col-lg-8 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart2.SetProperty("Width", Dvpanel_tablechart2_Width);
            ucDvpanel_tablechart2.SetProperty("AutoWidth", Dvpanel_tablechart2_Autowidth);
            ucDvpanel_tablechart2.SetProperty("AutoHeight", Dvpanel_tablechart2_Autoheight);
            ucDvpanel_tablechart2.SetProperty("Cls", Dvpanel_tablechart2_Cls);
            ucDvpanel_tablechart2.SetProperty("Title", Dvpanel_tablechart2_Title);
            ucDvpanel_tablechart2.SetProperty("Collapsible", Dvpanel_tablechart2_Collapsible);
            ucDvpanel_tablechart2.SetProperty("Collapsed", Dvpanel_tablechart2_Collapsed);
            ucDvpanel_tablechart2.SetProperty("ShowCollapseIcon", Dvpanel_tablechart2_Showcollapseicon);
            ucDvpanel_tablechart2.SetProperty("IconPosition", Dvpanel_tablechart2_Iconposition);
            ucDvpanel_tablechart2.SetProperty("AutoScroll", Dvpanel_tablechart2_Autoscroll);
            ucDvpanel_tablechart2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart2_Internalname, "DVPANEL_TABLECHART2Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART2Container"+"TableChart2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart2_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV14Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV15Parameters);
            ucUtchartcolumnline.SetProperty("ObjectName", Utchartcolumnline_Objectname);
            ucUtchartcolumnline.SetProperty("Height", Utchartcolumnline_Height);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("ChartType", Utchartcolumnline_Charttype);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV16ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV17ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV18DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV19FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV20ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV21ItemCollapseData);
            ucUtchartcolumnline.Render(context, "queryviewer", Utchartcolumnline_Internalname, "UTCHARTCOLUMNLINEContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 col-lg-4 CellMarginTop", "left", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablenotifications.SetProperty("Width", Dvpanel_tablenotifications_Width);
            ucDvpanel_tablenotifications.SetProperty("AutoWidth", Dvpanel_tablenotifications_Autowidth);
            ucDvpanel_tablenotifications.SetProperty("AutoHeight", Dvpanel_tablenotifications_Autoheight);
            ucDvpanel_tablenotifications.SetProperty("Cls", Dvpanel_tablenotifications_Cls);
            ucDvpanel_tablenotifications.SetProperty("Title", Dvpanel_tablenotifications_Title);
            ucDvpanel_tablenotifications.SetProperty("Collapsible", Dvpanel_tablenotifications_Collapsible);
            ucDvpanel_tablenotifications.SetProperty("Collapsed", Dvpanel_tablenotifications_Collapsed);
            ucDvpanel_tablenotifications.SetProperty("ShowCollapseIcon", Dvpanel_tablenotifications_Showcollapseicon);
            ucDvpanel_tablenotifications.SetProperty("IconPosition", Dvpanel_tablenotifications_Iconposition);
            ucDvpanel_tablenotifications.SetProperty("AutoScroll", Dvpanel_tablenotifications_Autoscroll);
            ucDvpanel_tablenotifications.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablenotifications_Internalname, "DVPANEL_TABLENOTIFICATIONSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLENOTIFICATIONSContainer"+"TableNotifications"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotifications_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 NotificationSubtitleCell", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationssubtitle_Internalname, lblNotificationssubtitle_Caption, "", "", lblNotificationssubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 GridNoBorderNoHeader CellMarginTop HasGridEmpowerer", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridnotificationsContainer.SetWrapped(nGXWrapped);
            StartGridControl129( ) ;
         }
         if ( wbEnd == 129 )
         {
            wbEnd = 0;
            nRC_GXsfl_129 = (int)(nGXsfl_129_idx-1);
            if ( GridnotificationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridnotificationsContainer.AddObjectProperty("GRIDNOTIFICATIONS_nEOF", GRIDNOTIFICATIONS_nEOF);
               GridnotificationsContainer.AddObjectProperty("GRIDNOTIFICATIONS_nFirstRecordOnPage", GRIDNOTIFICATIONS_nFirstRecordOnPage);
               AV30GXV5 = nGXsfl_129_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridnotificationsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridnotifications", GridnotificationsContainer, subGridnotifications_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridnotificationsContainerData", GridnotificationsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridnotificationsContainerData"+"V", GridnotificationsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridnotificationsContainerData"+"V"+"\" value='"+GridnotificationsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* User Defined Control */
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* User Defined Control */
            ucGridnotifications_empowerer.Render(context, "wwp.gridempowerer", Gridnotifications_empowerer_Internalname, "GRIDNOTIFICATIONS_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 101 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  AV26GXV1 = nGXsfl_101_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 129 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridnotificationsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridnotificationsContainer.AddObjectProperty("GRIDNOTIFICATIONS_nEOF", GRIDNOTIFICATIONS_nEOF);
                  GridnotificationsContainer.AddObjectProperty("GRIDNOTIFICATIONS_nFirstRecordOnPage", GRIDNOTIFICATIONS_nFirstRecordOnPage);
                  AV30GXV5 = nGXsfl_129_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridnotificationsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridnotifications", GridnotificationsContainer, subGridnotifications_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridnotificationsContainerData", GridnotificationsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridnotificationsContainerData"+"V", GridnotificationsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridnotificationsContainerData"+"V"+"\" value='"+GridnotificationsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START092( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_11-163677", 0) ;
            }
            Form.Meta.addItem("description", "Inicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP090( ) ;
      }

      protected void WS092( )
      {
         START092( ) ;
         EVT092( ) ;
      }

      protected void EVT092( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDNOTIFICATIONSPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDNOTIFICATIONSPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridnotifications_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridnotifications_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridnotifications_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridnotifications_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_101_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
                              SubsflControlProps_1012( ) ;
                              AV26GXV1 = (int)(nGXsfl_101_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV5HomeSampleData.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
                              {
                                 AV5HomeSampleData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E11092 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E12092 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E13092 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "GRIDNOTIFICATIONS.LOAD") == 0 )
                           {
                              nGXsfl_129_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
                              SubsflControlProps_1293( ) ;
                              AV30GXV5 = (int)(nGXsfl_129_idx+GRIDNOTIFICATIONS_nFirstRecordOnPage);
                              if ( ( AV7SDTNotificationsData.Count >= AV30GXV5 ) && ( AV30GXV5 > 0 ) )
                              {
                                 AV7SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV30GXV5));
                                 AV6NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                                 AssignAttri("", false, edtavNotificationicon_Internalname, AV6NotificationIcon);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRIDNOTIFICATIONS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E14093 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE092( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA092( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavCard1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1012( ) ;
         while ( nGXsfl_101_idx <= nRC_GXsfl_101 )
         {
            sendrow_1012( ) ;
            nGXsfl_101_idx = ((subGrid_Islastpage==1)&&(nGXsfl_101_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1012( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxnrGridnotifications_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1293( ) ;
         while ( nGXsfl_129_idx <= nRC_GXsfl_129 )
         {
            sendrow_1293( ) ;
            nGXsfl_129_idx = ((subGridnotifications_Islastpage==1)&&(nGXsfl_129_idx+1>subGridnotifications_fnc_Recordsperpage( )) ? 1 : nGXsfl_129_idx+1);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1293( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridnotificationsContainer)) ;
         /* End function gxnrGridnotifications_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       int subGridnotifications_Rows ,
                                       GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData ,
                                       GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> AV7SDTNotificationsData )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E12092 ();
         GRID_nCurrentRecord = 0;
         RF092( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void gxgrGridnotifications_refresh( int subGrid_Rows ,
                                                    int subGridnotifications_Rows ,
                                                    GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> AV7SDTNotificationsData ,
                                                    GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E12092 ();
         GRIDNOTIFICATIONS_nCurrentRecord = 0;
         RF093( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridnotifications_refresh */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF092( ) ;
         RF093( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCard1_value_Enabled = 0;
         AssignProp("", false, edtavCard1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard1_value_Enabled), 5, 0), true);
         edtavCard2_value_Enabled = 0;
         AssignProp("", false, edtavCard2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard2_value_Enabled), 5, 0), true);
         edtavCard3_value_Enabled = 0;
         AssignProp("", false, edtavCard3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard3_value_Enabled), 5, 0), true);
         edtavCard4_value_Enabled = 0;
         AssignProp("", false, edtavCard4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard4_value_Enabled), 5, 0), true);
         edtavHomesampledata__productname_Enabled = 0;
         AssignProp("", false, edtavHomesampledata__productname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomesampledata__productname_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavHomesampledata__productprice_Enabled = 0;
         AssignProp("", false, edtavHomesampledata__productprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomesampledata__productprice_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         cmbavHomesampledata__productstatus.Enabled = 0;
         AssignProp("", false, cmbavHomesampledata__productstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavHomesampledata__productstatus.Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavNotificationicon_Enabled = 0;
         AssignProp("", false, edtavNotificationicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationicon_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationiconclass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationiconclass_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_129_Refreshing);
      }

      protected void RF092( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 101;
         /* Execute user event: Refresh */
         E12092 ();
         nGXsfl_101_idx = 1;
         sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
         SubsflControlProps_1012( ) ;
         bGXsfl_101_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1012( ) ;
            E13092 ();
            if ( ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_101_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               E13092 ();
            }
            wbEnd = 101;
            WB090( ) ;
         }
         bGXsfl_101_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes092( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMESAMPLEDATA", GetSecureSignedToken( "", AV5HomeSampleData, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
      }

      protected void RF093( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridnotificationsContainer.ClearRows();
         }
         wbStart = 129;
         nGXsfl_129_idx = 1;
         sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
         SubsflControlProps_1293( ) ;
         bGXsfl_129_Refreshing = true;
         GridnotificationsContainer.AddObjectProperty("GridName", "Gridnotifications");
         GridnotificationsContainer.AddObjectProperty("CmpContext", "");
         GridnotificationsContainer.AddObjectProperty("InMasterPage", "false");
         GridnotificationsContainer.AddObjectProperty("Class", "WorkWith");
         GridnotificationsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridnotificationsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridnotificationsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Backcolorstyle), 1, 0, ".", "")));
         GridnotificationsContainer.PageSize = subGridnotifications_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1293( ) ;
            E14093 ();
            if ( ( GRIDNOTIFICATIONS_nCurrentRecord > 0 ) && ( GRIDNOTIFICATIONS_nGridOutOfScope == 0 ) && ( nGXsfl_129_idx == 1 ) )
            {
               GRIDNOTIFICATIONS_nCurrentRecord = 0;
               GRIDNOTIFICATIONS_nGridOutOfScope = 1;
               subgridnotifications_firstpage( ) ;
               E14093 ();
            }
            wbEnd = 129;
            WB090( ) ;
         }
         bGXsfl_129_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes093( )
      {
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return AV5HomeSampleData.Count ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGridnotifications_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGridnotifications_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGridnotifications_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGridnotifications_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, subGridnotifications_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected int subGridnotifications_fnc_Pagecount( )
      {
         GRIDNOTIFICATIONS_nRecordCount = subGridnotifications_fnc_Recordcount( );
         if ( ((int)((GRIDNOTIFICATIONS_nRecordCount) % (subGridnotifications_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRIDNOTIFICATIONS_nRecordCount/ (decimal)(subGridnotifications_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRIDNOTIFICATIONS_nRecordCount/ (decimal)(subGridnotifications_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGridnotifications_fnc_Recordcount( )
      {
         return AV7SDTNotificationsData.Count ;
      }

      protected int subGridnotifications_fnc_Recordsperpage( )
      {
         if ( subGridnotifications_Rows > 0 )
         {
            return subGridnotifications_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridnotifications_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRIDNOTIFICATIONS_nFirstRecordOnPage/ (decimal)(subGridnotifications_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgridnotifications_firstpage( )
      {
         GRIDNOTIFICATIONS_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotifications_refresh( subGrid_Rows, subGridnotifications_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridnotifications_nextpage( )
      {
         GRIDNOTIFICATIONS_nRecordCount = subGridnotifications_fnc_Recordcount( );
         if ( ( GRIDNOTIFICATIONS_nRecordCount >= subGridnotifications_fnc_Recordsperpage( ) ) && ( GRIDNOTIFICATIONS_nEOF == 0 ) )
         {
            GRIDNOTIFICATIONS_nFirstRecordOnPage = (long)(GRIDNOTIFICATIONS_nFirstRecordOnPage+subGridnotifications_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         GridnotificationsContainer.AddObjectProperty("GRIDNOTIFICATIONS_nFirstRecordOnPage", GRIDNOTIFICATIONS_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotifications_refresh( subGrid_Rows, subGridnotifications_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDNOTIFICATIONS_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridnotifications_previouspage( )
      {
         if ( GRIDNOTIFICATIONS_nFirstRecordOnPage >= subGridnotifications_fnc_Recordsperpage( ) )
         {
            GRIDNOTIFICATIONS_nFirstRecordOnPage = (long)(GRIDNOTIFICATIONS_nFirstRecordOnPage-subGridnotifications_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotifications_refresh( subGrid_Rows, subGridnotifications_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridnotifications_lastpage( )
      {
         GRIDNOTIFICATIONS_nRecordCount = subGridnotifications_fnc_Recordcount( );
         if ( GRIDNOTIFICATIONS_nRecordCount > subGridnotifications_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDNOTIFICATIONS_nRecordCount) % (subGridnotifications_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDNOTIFICATIONS_nFirstRecordOnPage = (long)(GRIDNOTIFICATIONS_nRecordCount-subGridnotifications_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDNOTIFICATIONS_nFirstRecordOnPage = (long)(GRIDNOTIFICATIONS_nRecordCount-((int)((GRIDNOTIFICATIONS_nRecordCount) % (subGridnotifications_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDNOTIFICATIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotifications_refresh( subGrid_Rows, subGridnotifications_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridnotifications_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDNOTIFICATIONS_nFirstRecordOnPage = (long)(subGridnotifications_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDNOTIFICATIONS_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotifications_refresh( subGrid_Rows, subGridnotifications_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCard1_value_Enabled = 0;
         AssignProp("", false, edtavCard1_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard1_value_Enabled), 5, 0), true);
         edtavCard2_value_Enabled = 0;
         AssignProp("", false, edtavCard2_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard2_value_Enabled), 5, 0), true);
         edtavCard3_value_Enabled = 0;
         AssignProp("", false, edtavCard3_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard3_value_Enabled), 5, 0), true);
         edtavCard4_value_Enabled = 0;
         AssignProp("", false, edtavCard4_value_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCard4_value_Enabled), 5, 0), true);
         edtavHomesampledata__productname_Enabled = 0;
         AssignProp("", false, edtavHomesampledata__productname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomesampledata__productname_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavHomesampledata__productprice_Enabled = 0;
         AssignProp("", false, edtavHomesampledata__productprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomesampledata__productprice_Enabled), 5, 0), !bGXsfl_101_Refreshing);
         cmbavHomesampledata__productstatus.Enabled = 0;
         AssignProp("", false, cmbavHomesampledata__productstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavHomesampledata__productstatus.Enabled), 5, 0), !bGXsfl_101_Refreshing);
         edtavNotificationicon_Enabled = 0;
         AssignProp("", false, edtavNotificationicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationicon_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationiconclass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationiconclass_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_129_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP090( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11092 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Homesampledata"), AV5HomeSampleData);
            ajax_req_read_hidden_sdt(cgiGet( "Sdtnotificationsdata"), AV7SDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV14Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vPARAMETERS"), AV15Parameters);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCLICKDATA"), AV16ItemClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMDOUBLECLICKDATA"), AV17ItemDoubleClickData);
            ajax_req_read_hidden_sdt(cgiGet( "vDRAGANDDROPDATA"), AV18DragAndDropData);
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERCHANGEDDATA"), AV19FilterChangedData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMEXPANDDATA"), AV20ItemExpandData);
            ajax_req_read_hidden_sdt(cgiGet( "vITEMCOLLAPSEDATA"), AV21ItemCollapseData);
            ajax_req_read_hidden_sdt(cgiGet( "vHOMESAMPLEDATA"), AV5HomeSampleData);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTNOTIFICATIONSDATA"), AV7SDTNotificationsData);
            /* Read saved values. */
            nRC_GXsfl_101 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_101"), ",", "."));
            nRC_GXsfl_129 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_129"), ",", "."));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."));
            GRIDNOTIFICATIONS_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRIDNOTIFICATIONS_nFirstRecordOnPage"), ",", "."));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."));
            GRIDNOTIFICATIONS_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRIDNOTIFICATIONS_nEOF"), ",", "."));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            subGridnotifications_Rows = (int)(context.localUtil.CToN( cgiGet( "GRIDNOTIFICATIONS_Rows"), ",", "."));
            GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Rows), 6, 0, ".", "")));
            Utchartstackedbar_Objectname = cgiGet( "UTCHARTSTACKEDBAR_Objectname");
            Utchartstackedbar_Height = cgiGet( "UTCHARTSTACKEDBAR_Height");
            Utchartstackedbar_Type = cgiGet( "UTCHARTSTACKEDBAR_Type");
            Utchartstackedbar_Charttype = cgiGet( "UTCHARTSTACKEDBAR_Charttype");
            Dvpanel_tablechart1_Width = cgiGet( "DVPANEL_TABLECHART1_Width");
            Dvpanel_tablechart1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autowidth"));
            Dvpanel_tablechart1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoheight"));
            Dvpanel_tablechart1_Cls = cgiGet( "DVPANEL_TABLECHART1_Cls");
            Dvpanel_tablechart1_Title = cgiGet( "DVPANEL_TABLECHART1_Title");
            Dvpanel_tablechart1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsible"));
            Dvpanel_tablechart1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsed"));
            Dvpanel_tablechart1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Showcollapseicon"));
            Dvpanel_tablechart1_Iconposition = cgiGet( "DVPANEL_TABLECHART1_Iconposition");
            Dvpanel_tablechart1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoscroll"));
            Utchartcolumnline_Objectname = cgiGet( "UTCHARTCOLUMNLINE_Objectname");
            Utchartcolumnline_Height = cgiGet( "UTCHARTCOLUMNLINE_Height");
            Utchartcolumnline_Type = cgiGet( "UTCHARTCOLUMNLINE_Type");
            Utchartcolumnline_Charttype = cgiGet( "UTCHARTCOLUMNLINE_Charttype");
            Dvpanel_tablechart2_Width = cgiGet( "DVPANEL_TABLECHART2_Width");
            Dvpanel_tablechart2_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART2_Autowidth"));
            Dvpanel_tablechart2_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART2_Autoheight"));
            Dvpanel_tablechart2_Cls = cgiGet( "DVPANEL_TABLECHART2_Cls");
            Dvpanel_tablechart2_Title = cgiGet( "DVPANEL_TABLECHART2_Title");
            Dvpanel_tablechart2_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART2_Collapsible"));
            Dvpanel_tablechart2_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART2_Collapsed"));
            Dvpanel_tablechart2_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART2_Showcollapseicon"));
            Dvpanel_tablechart2_Iconposition = cgiGet( "DVPANEL_TABLECHART2_Iconposition");
            Dvpanel_tablechart2_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART2_Autoscroll"));
            Dvpanel_tablenotifications_Width = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Width");
            Dvpanel_tablenotifications_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autowidth"));
            Dvpanel_tablenotifications_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoheight"));
            Dvpanel_tablenotifications_Cls = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Cls");
            Dvpanel_tablenotifications_Title = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Title");
            Dvpanel_tablenotifications_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsible"));
            Dvpanel_tablenotifications_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsed"));
            Dvpanel_tablenotifications_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon"));
            Dvpanel_tablenotifications_Iconposition = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Iconposition");
            Dvpanel_tablenotifications_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoscroll"));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Gridnotifications_empowerer_Gridinternalname = cgiGet( "GRIDNOTIFICATIONS_EMPOWERER_Gridinternalname");
            nRC_GXsfl_101 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_101"), ",", "."));
            nGXsfl_101_fel_idx = 0;
            while ( nGXsfl_101_fel_idx < nRC_GXsfl_101 )
            {
               nGXsfl_101_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_101_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_fel_idx+1);
               sGXsfl_101_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1012( ) ;
               AV26GXV1 = (int)(nGXsfl_101_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV5HomeSampleData.Count >= AV26GXV1 ) && ( AV26GXV1 > 0 ) )
               {
                  AV5HomeSampleData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1));
               }
            }
            if ( nGXsfl_101_fel_idx == 0 )
            {
               nGXsfl_101_idx = 1;
               sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
               SubsflControlProps_1012( ) ;
            }
            nGXsfl_101_fel_idx = 1;
            nRC_GXsfl_129 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_129"), ",", "."));
            nGXsfl_129_fel_idx = 0;
            while ( nGXsfl_129_fel_idx < nRC_GXsfl_129 )
            {
               nGXsfl_129_fel_idx = ((subGridnotifications_Islastpage==1)&&(nGXsfl_129_fel_idx+1>subGridnotifications_fnc_Recordsperpage( )) ? 1 : nGXsfl_129_fel_idx+1);
               sGXsfl_129_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1293( ) ;
               AV30GXV5 = (int)(nGXsfl_129_fel_idx+GRIDNOTIFICATIONS_nFirstRecordOnPage);
               if ( ( AV7SDTNotificationsData.Count >= AV30GXV5 ) && ( AV30GXV5 > 0 ) )
               {
                  AV7SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV30GXV5));
                  AV6NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
               }
            }
            if ( nGXsfl_129_fel_idx == 0 )
            {
               nGXsfl_129_idx = 1;
               sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
               SubsflControlProps_1293( ) ;
            }
            nGXsfl_129_fel_idx = 1;
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD1_VALUE");
               GX_FocusControl = edtavCard1_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Card1_Value = 0;
               AssignAttri("", false, "AV8Card1_Value", StringUtil.LTrimStr( (decimal)(AV8Card1_Value), 8, 0));
            }
            else
            {
               AV8Card1_Value = (int)(context.localUtil.CToN( cgiGet( edtavCard1_value_Internalname), ",", "."));
               AssignAttri("", false, "AV8Card1_Value", StringUtil.LTrimStr( (decimal)(AV8Card1_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD2_VALUE");
               GX_FocusControl = edtavCard2_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9Card2_Value = 0;
               AssignAttri("", false, "AV9Card2_Value", StringUtil.LTrimStr( (decimal)(AV9Card2_Value), 8, 0));
            }
            else
            {
               AV9Card2_Value = (int)(context.localUtil.CToN( cgiGet( edtavCard2_value_Internalname), ",", "."));
               AssignAttri("", false, "AV9Card2_Value", StringUtil.LTrimStr( (decimal)(AV9Card2_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD3_VALUE");
               GX_FocusControl = edtavCard3_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10Card3_Value = 0;
               AssignAttri("", false, "AV10Card3_Value", StringUtil.LTrimStr( (decimal)(AV10Card3_Value), 8, 0));
            }
            else
            {
               AV10Card3_Value = (int)(context.localUtil.CToN( cgiGet( edtavCard3_value_Internalname), ",", "."));
               AssignAttri("", false, "AV10Card3_Value", StringUtil.LTrimStr( (decimal)(AV10Card3_Value), 8, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCARD4_VALUE");
               GX_FocusControl = edtavCard4_value_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11Card4_Value = 0;
               AssignAttri("", false, "AV11Card4_Value", StringUtil.LTrimStr( (decimal)(AV11Card4_Value), 8, 0));
            }
            else
            {
               AV11Card4_Value = (int)(context.localUtil.CToN( cgiGet( edtavCard4_value_Internalname), ",", "."));
               AssignAttri("", false, "AV11Card4_Value", StringUtil.LTrimStr( (decimal)(AV11Card4_Value), 8, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E11092 ();
         if (returnInSub) return;
      }

      protected void E11092( )
      {
         /* Start Routine */
         returnInSub = false;
         AV8Card1_Value = 352;
         AssignAttri("", false, "AV8Card1_Value", StringUtil.LTrimStr( (decimal)(AV8Card1_Value), 8, 0));
         AV9Card2_Value = 7552;
         AssignAttri("", false, "AV9Card2_Value", StringUtil.LTrimStr( (decimal)(AV9Card2_Value), 8, 0));
         AV10Card3_Value = 825;
         AssignAttri("", false, "AV10Card3_Value", StringUtil.LTrimStr( (decimal)(AV10Card3_Value), 8, 0));
         AV11Card4_Value = 2540;
         AssignAttri("", false, "AV11Card4_Value", StringUtil.LTrimStr( (decimal)(AV11Card4_Value), 8, 0));
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = AV5HomeSampleData;
         new GeneXus.Programs.wwpbaseobjects.gethomesampledata(context ).execute( out  GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1) ;
         AV5HomeSampleData = GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1;
         gx_BV101 = true;
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "ProductStatus";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "Check";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2 = AV7SDTNotificationsData;
         new GeneXus.Programs.wwpbaseobjects.getnotificationsamples(context ).execute( out  GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2) ;
         AV7SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2;
         gx_BV129 = true;
         if ( AV7SDTNotificationsData.Count == 0 )
         {
            lblNotificationssubtitle_Caption = "No tienes nuevas notificaciones";
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else if ( AV7SDTNotificationsData.Count == 1 )
         {
            lblNotificationssubtitle_Caption = "Tienes 1 nueva notificación";
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else
         {
            lblNotificationssubtitle_Caption = StringUtil.Format( "Tienes %1 nuevas notificaciones", StringUtil.Trim( StringUtil.Str( (decimal)(AV7SDTNotificationsData.Count), 9, 0)), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         divTablechart1_Height = 447;
         AssignProp("", false, divTablechart1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart1_Height), 9, 0), true);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Gridnotifications_empowerer_Gridinternalname = subGridnotifications_Internalname;
         ucGridnotifications_empowerer.SendProperty(context, "", false, Gridnotifications_empowerer_Internalname, "GridInternalName", Gridnotifications_empowerer_Gridinternalname);
         subGridnotifications_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Rows), 6, 0, ".", "")));
      }

      protected void E12092( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         cmbavHomesampledata__productstatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbavHomesampledata__productstatus_Internalname, "Columnheaderclass", cmbavHomesampledata__productstatus_Columnheaderclass, !bGXsfl_101_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E13092( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV26GXV1 = 1;
         while ( AV26GXV1 <= AV5HomeSampleData.Count )
         {
            AV5HomeSampleData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1));
            if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)(AV5HomeSampleData.CurrentItem)).gxTpr_Productstatus == 1 )
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)(AV5HomeSampleData.CurrentItem)).gxTpr_Productstatus == 2 )
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)(AV5HomeSampleData.CurrentItem)).gxTpr_Productstatus == 4 )
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
            }
            else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)(AV5HomeSampleData.CurrentItem)).gxTpr_Productstatus == 3 )
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 101;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1012( ) ;
               GRID_nEOF = 0;
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               if ( GRID_nCurrentRecord + 1 >= subGrid_fnc_Recordcount( ) )
               {
                  GRID_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               }
            }
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_101_Refreshing )
            {
               DoAjaxLoad(101, GridRow);
            }
            AV26GXV1 = (int)(AV26GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      private void E14093( )
      {
         /* Gridnotifications_Load Routine */
         returnInSub = false;
         AV30GXV5 = 1;
         while ( AV30GXV5 <= AV7SDTNotificationsData.Count )
         {
            AV7SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV30GXV5));
            edtavNotificationicon_Format = 2;
            AV6NotificationIcon = StringUtil.Format( "<i class=\"%1 %2\"></i>", ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)(AV7SDTNotificationsData.CurrentItem)).gxTpr_Notificationiconclass, "NotificationFontIconGrid", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavNotificationicon_Internalname, AV6NotificationIcon);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 129;
            }
            if ( ( subGridnotifications_Islastpage == 1 ) || ( subGridnotifications_Rows == 0 ) || ( ( GRIDNOTIFICATIONS_nCurrentRecord >= GRIDNOTIFICATIONS_nFirstRecordOnPage ) && ( GRIDNOTIFICATIONS_nCurrentRecord < GRIDNOTIFICATIONS_nFirstRecordOnPage + subGridnotifications_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_1293( ) ;
               GRIDNOTIFICATIONS_nEOF = 0;
               GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nEOF), 1, 0, ".", "")));
               if ( GRIDNOTIFICATIONS_nCurrentRecord + 1 >= subGridnotifications_fnc_Recordcount( ) )
               {
                  GRIDNOTIFICATIONS_nEOF = 1;
                  GxWebStd.gx_hidden_field( context, "GRIDNOTIFICATIONS_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTIFICATIONS_nEOF), 1, 0, ".", "")));
               }
            }
            GRIDNOTIFICATIONS_nCurrentRecord = (long)(GRIDNOTIFICATIONS_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_129_Refreshing )
            {
               DoAjaxLoad(129, GridnotificationsRow);
            }
            AV30GXV5 = (int)(AV30GXV5+1);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table4_93_092( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCard4_moreinfotable_Internalname, tblCard4_moreinfotable_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard4_moreinfo_Internalname, "More info", "", "", lblCard4_moreinfo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoAdmin", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard4_moreinfoicon_Internalname, "<i class='MoreInfoAdminIcon fa fa-arrow-circle-right'></i>", "", "", lblCard4_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_93_092e( true) ;
         }
         else
         {
            wb_table4_93_092e( false) ;
         }
      }

      protected void wb_table3_71_092( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCard3_moreinfotable_Internalname, tblCard3_moreinfotable_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard3_moreinfo_Internalname, "More info", "", "", lblCard3_moreinfo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoAdmin", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard3_moreinfoicon_Internalname, "<i class='MoreInfoAdminIcon fa fa-arrow-circle-right'></i>", "", "", lblCard3_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_71_092e( true) ;
         }
         else
         {
            wb_table3_71_092e( false) ;
         }
      }

      protected void wb_table2_49_092( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCard2_moreinfotable_Internalname, tblCard2_moreinfotable_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard2_moreinfo_Internalname, "More info", "", "", lblCard2_moreinfo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoAdmin", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard2_moreinfoicon_Internalname, "<i class='MoreInfoAdminIcon fa fa-arrow-circle-right'></i>", "", "", lblCard2_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_092e( true) ;
         }
         else
         {
            wb_table2_49_092e( false) ;
         }
      }

      protected void wb_table1_27_092( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCard1_moreinfotable_Internalname, tblCard1_moreinfotable_Internalname, "", "", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard1_moreinfo_Internalname, "More info", "", "", lblCard1_moreinfo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockMoreInfoAdmin", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCard1_moreinfoicon_Internalname, "<i class='MoreInfoAdminIcon fa fa-arrow-circle-right'></i>", "", "", lblCard1_moreinfoicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_Home.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_27_092e( true) ;
         }
         else
         {
            wb_table1_27_092e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA092( ) ;
         WS092( ) ;
         WE092( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
         AddStyleSheetFile("QueryViewer/highcharts/css/highcharts.css", "");
         AddStyleSheetFile("QueryViewer/QueryViewer.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20237314225913", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("home.js", "?20237314225915", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1012( )
      {
         edtavHomesampledata__productname_Internalname = "HOMESAMPLEDATA__PRODUCTNAME_"+sGXsfl_101_idx;
         edtavHomesampledata__productprice_Internalname = "HOMESAMPLEDATA__PRODUCTPRICE_"+sGXsfl_101_idx;
         cmbavHomesampledata__productstatus_Internalname = "HOMESAMPLEDATA__PRODUCTSTATUS_"+sGXsfl_101_idx;
      }

      protected void SubsflControlProps_fel_1012( )
      {
         edtavHomesampledata__productname_Internalname = "HOMESAMPLEDATA__PRODUCTNAME_"+sGXsfl_101_fel_idx;
         edtavHomesampledata__productprice_Internalname = "HOMESAMPLEDATA__PRODUCTPRICE_"+sGXsfl_101_fel_idx;
         cmbavHomesampledata__productstatus_Internalname = "HOMESAMPLEDATA__PRODUCTSTATUS_"+sGXsfl_101_fel_idx;
      }

      protected void sendrow_1012( )
      {
         SubsflControlProps_1012( ) ;
         WB090( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_101_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_101_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_101_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHomesampledata__productname_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productname,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHomesampledata__productname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavHomesampledata__productname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHomesampledata__productprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productprice, 11, 1, ",", "")),StringUtil.LTrim( ((edtavHomesampledata__productprice_Enabled!=0) ? context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productprice, "$ ZZZ,ZZ9.9") : context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productprice, "$ ZZZ,ZZ9.9"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHomesampledata__productprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavHomesampledata__productprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)101,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbavHomesampledata__productstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "HOMESAMPLEDATA__PRODUCTSTATUS_" + sGXsfl_101_idx;
               cmbavHomesampledata__productstatus.Name = GXCCtl;
               cmbavHomesampledata__productstatus.WebTags = "";
               cmbavHomesampledata__productstatus.addItem("1", "Available", 0);
               cmbavHomesampledata__productstatus.addItem("2", "Missing", 0);
               cmbavHomesampledata__productstatus.addItem("3", "Comming Soon", 0);
               cmbavHomesampledata__productstatus.addItem("4", "Ordered", 0);
               if ( cmbavHomesampledata__productstatus.ItemCount > 0 )
               {
                  if ( ( AV26GXV1 > 0 ) && ( AV5HomeSampleData.Count >= AV26GXV1 ) && (0==((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productstatus) )
                  {
                     ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productstatus = (short)(NumberUtil.Val( cmbavHomesampledata__productstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productstatus), 1, 0))), "."));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavHomesampledata__productstatus,(string)cmbavHomesampledata__productstatus_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productstatus), 1, 0)),(short)1,(string)cmbavHomesampledata__productstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbavHomesampledata__productstatus.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbavHomesampledata__productstatus_Columnclass,(string)cmbavHomesampledata__productstatus_Columnheaderclass,(string)"",(string)"",(bool)true,(short)0});
            cmbavHomesampledata__productstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productstatus), 1, 0));
            AssignProp("", false, cmbavHomesampledata__productstatus_Internalname, "Values", (string)(cmbavHomesampledata__productstatus.ToJavascriptSource()), !bGXsfl_101_Refreshing);
            send_integrity_lvl_hashes092( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_101_idx = ((subGrid_Islastpage==1)&&(nGXsfl_101_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_101_idx+1);
            sGXsfl_101_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_101_idx), 4, 0), 4, "0");
            SubsflControlProps_1012( ) ;
         }
         /* End function sendrow_1012 */
      }

      protected void SubsflControlProps_1293( )
      {
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_129_idx;
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_129_idx;
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_129_idx;
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_129_idx;
      }

      protected void SubsflControlProps_fel_1293( )
      {
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_129_fel_idx;
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_129_fel_idx;
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_129_fel_idx;
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_129_fel_idx;
      }

      protected void sendrow_1293( )
      {
         SubsflControlProps_1293( ) ;
         WB090( ) ;
         if ( ( subGridnotifications_Rows * 1 == 0 ) || ( nGXsfl_129_idx <= subGridnotifications_fnc_Recordsperpage( ) * 1 ) )
         {
            GridnotificationsRow = GXWebRow.GetNew(context,GridnotificationsContainer);
            if ( subGridnotifications_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridnotifications_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridnotifications_Class, "") != 0 )
               {
                  subGridnotifications_Linesclass = subGridnotifications_Class+"Odd";
               }
            }
            else if ( subGridnotifications_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridnotifications_Backstyle = 0;
               subGridnotifications_Backcolor = subGridnotifications_Allbackcolor;
               if ( StringUtil.StrCmp(subGridnotifications_Class, "") != 0 )
               {
                  subGridnotifications_Linesclass = subGridnotifications_Class+"Uniform";
               }
            }
            else if ( subGridnotifications_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridnotifications_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridnotifications_Class, "") != 0 )
               {
                  subGridnotifications_Linesclass = subGridnotifications_Class+"Odd";
               }
               subGridnotifications_Backcolor = (int)(0x0);
            }
            else if ( subGridnotifications_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridnotifications_Backstyle = 1;
               if ( ((int)((nGXsfl_129_idx) % (2))) == 0 )
               {
                  subGridnotifications_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridnotifications_Class, "") != 0 )
                  {
                     subGridnotifications_Linesclass = subGridnotifications_Class+"Even";
                  }
               }
               else
               {
                  subGridnotifications_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridnotifications_Class, "") != 0 )
                  {
                     subGridnotifications_Linesclass = subGridnotifications_Class+"Odd";
                  }
               }
            }
            if ( GridnotificationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_129_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridnotificationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridnotificationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationicon_Internalname,(string)AV6NotificationIcon,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationicon_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNotificationicon_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)edtavNotificationicon_Format,(short)129,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotificationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridnotificationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationiconclass_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV30GXV5)).gxTpr_Notificationiconclass,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationiconclass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtnotificationsdata__notificationiconclass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotificationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridnotificationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationtitle_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV30GXV5)).gxTpr_Notificationtitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationtitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtnotificationsdata__notificationtitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotificationsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeSecondary";
            GridnotificationsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationdatetime_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV30GXV5)).gxTpr_Notificationdatetime, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem)AV7SDTNotificationsData.Item(AV30GXV5)).gxTpr_Notificationdatetime, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationdatetime_Jsonclick,(short)0,(string)"AttributeSecondary",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtnotificationsdata__notificationdatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)129,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes093( ) ;
            GridnotificationsContainer.AddRow(GridnotificationsRow);
            nGXsfl_129_idx = ((subGridnotifications_Islastpage==1)&&(nGXsfl_129_idx+1>subGridnotifications_fnc_Recordsperpage( )) ? 1 : nGXsfl_129_idx+1);
            sGXsfl_129_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_129_idx), 4, 0), 4, "0");
            SubsflControlProps_1293( ) ;
         }
         /* End function sendrow_1293 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "HOMESAMPLEDATA__PRODUCTSTATUS_" + sGXsfl_101_idx;
         cmbavHomesampledata__productstatus.Name = GXCCtl;
         cmbavHomesampledata__productstatus.WebTags = "";
         cmbavHomesampledata__productstatus.addItem("1", "Available", 0);
         cmbavHomesampledata__productstatus.addItem("2", "Missing", 0);
         cmbavHomesampledata__productstatus.addItem("3", "Comming Soon", 0);
         cmbavHomesampledata__productstatus.addItem("4", "Ordered", 0);
         if ( cmbavHomesampledata__productstatus.ItemCount > 0 )
         {
            if ( ( AV26GXV1 > 0 ) && ( AV5HomeSampleData.Count >= AV26GXV1 ) && (0==((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productstatus) )
            {
               ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productstatus = (short)(NumberUtil.Val( cmbavHomesampledata__productstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV26GXV1)).gxTpr_Productstatus), 1, 0))), "."));
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl101( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"101\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHomesampledata__productname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHomesampledata__productprice_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavHomesampledata__productstatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavHomesampledata__productstatus_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavHomesampledata__productstatus.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl129( )
      {
         if ( GridnotificationsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridnotificationsContainer"+"DivS\" data-gxgridid=\"129\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridnotifications_Internalname, subGridnotifications_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridnotifications_Backcolorstyle == 0 )
            {
               subGridnotifications_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridnotifications_Class) > 0 )
               {
                  subGridnotifications_Linesclass = subGridnotifications_Class+"Title";
               }
            }
            else
            {
               subGridnotifications_Titlebackstyle = 1;
               if ( subGridnotifications_Backcolorstyle == 1 )
               {
                  subGridnotifications_Titlebackcolor = subGridnotifications_Allbackcolor;
                  if ( StringUtil.Len( subGridnotifications_Class) > 0 )
                  {
                     subGridnotifications_Linesclass = subGridnotifications_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridnotifications_Class) > 0 )
                  {
                     subGridnotifications_Linesclass = subGridnotifications_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Notification Icon Class") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Title") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeSecondary"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Datetime") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridnotificationsContainer.AddObjectProperty("GridName", "Gridnotifications");
         }
         else
         {
            GridnotificationsContainer.AddObjectProperty("GridName", "Gridnotifications");
            GridnotificationsContainer.AddObjectProperty("Header", subGridnotifications_Header);
            GridnotificationsContainer.AddObjectProperty("Class", "WorkWith");
            GridnotificationsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Backcolorstyle), 1, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("CmpContext", "");
            GridnotificationsContainer.AddObjectProperty("InMasterPage", "false");
            GridnotificationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotificationsColumn.AddObjectProperty("Value", AV6NotificationIcon);
            GridnotificationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Enabled), 5, 0, ".", "")));
            GridnotificationsColumn.AddObjectProperty("Format", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Format), 4, 0, ".", "")));
            GridnotificationsContainer.AddColumnProperties(GridnotificationsColumn);
            GridnotificationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotificationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationiconclass_Enabled), 5, 0, ".", "")));
            GridnotificationsContainer.AddColumnProperties(GridnotificationsColumn);
            GridnotificationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotificationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0, ".", "")));
            GridnotificationsContainer.AddColumnProperties(GridnotificationsColumn);
            GridnotificationsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotificationsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0, ".", "")));
            GridnotificationsContainer.AddColumnProperties(GridnotificationsColumn);
            GridnotificationsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Selectedindex), 4, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Allowselection), 1, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Selectioncolor), 9, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Allowhovering), 1, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Hoveringcolor), 9, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Allowcollapsing), 1, 0, ".", "")));
            GridnotificationsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotifications_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         edtavCard1_value_Internalname = "vCARD1_VALUE";
         lblCard1_description_Internalname = "CARD1_DESCRIPTION";
         divCard1_content_Internalname = "CARD1_CONTENT";
         lblCard1_icon_Internalname = "CARD1_ICON";
         lblCard1_moreinfo_Internalname = "CARD1_MOREINFO";
         lblCard1_moreinfoicon_Internalname = "CARD1_MOREINFOICON";
         tblCard1_moreinfotable_Internalname = "CARD1_MOREINFOTABLE";
         divCard1_maintable_Internalname = "CARD1_MAINTABLE";
         edtavCard2_value_Internalname = "vCARD2_VALUE";
         lblCard2_description_Internalname = "CARD2_DESCRIPTION";
         divCard2_content_Internalname = "CARD2_CONTENT";
         lblCard2_icon_Internalname = "CARD2_ICON";
         lblCard2_moreinfo_Internalname = "CARD2_MOREINFO";
         lblCard2_moreinfoicon_Internalname = "CARD2_MOREINFOICON";
         tblCard2_moreinfotable_Internalname = "CARD2_MOREINFOTABLE";
         divCard2_maintable_Internalname = "CARD2_MAINTABLE";
         edtavCard3_value_Internalname = "vCARD3_VALUE";
         lblCard3_description_Internalname = "CARD3_DESCRIPTION";
         divCard3_content_Internalname = "CARD3_CONTENT";
         lblCard3_icon_Internalname = "CARD3_ICON";
         lblCard3_moreinfo_Internalname = "CARD3_MOREINFO";
         lblCard3_moreinfoicon_Internalname = "CARD3_MOREINFOICON";
         tblCard3_moreinfotable_Internalname = "CARD3_MOREINFOTABLE";
         divCard3_maintable_Internalname = "CARD3_MAINTABLE";
         edtavCard4_value_Internalname = "vCARD4_VALUE";
         lblCard4_description_Internalname = "CARD4_DESCRIPTION";
         divCard4_content_Internalname = "CARD4_CONTENT";
         lblCard4_icon_Internalname = "CARD4_ICON";
         lblCard4_moreinfo_Internalname = "CARD4_MOREINFO";
         lblCard4_moreinfoicon_Internalname = "CARD4_MOREINFOICON";
         tblCard4_moreinfotable_Internalname = "CARD4_MOREINFOTABLE";
         divCard4_maintable_Internalname = "CARD4_MAINTABLE";
         divTablecards_Internalname = "TABLECARDS";
         edtavHomesampledata__productname_Internalname = "HOMESAMPLEDATA__PRODUCTNAME";
         edtavHomesampledata__productprice_Internalname = "HOMESAMPLEDATA__PRODUCTPRICE";
         cmbavHomesampledata__productstatus_Internalname = "HOMESAMPLEDATA__PRODUCTSTATUS";
         Utchartstackedbar_Internalname = "UTCHARTSTACKEDBAR";
         divTablechart1_Internalname = "TABLECHART1";
         Dvpanel_tablechart1_Internalname = "DVPANEL_TABLECHART1";
         Utchartcolumnline_Internalname = "UTCHARTCOLUMNLINE";
         divTablechart2_Internalname = "TABLECHART2";
         Dvpanel_tablechart2_Internalname = "DVPANEL_TABLECHART2";
         lblNotificationssubtitle_Internalname = "NOTIFICATIONSSUBTITLE";
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON";
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS";
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE";
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME";
         divTablenotifications_Internalname = "TABLENOTIFICATIONS";
         Dvpanel_tablenotifications_Internalname = "DVPANEL_TABLENOTIFICATIONS";
         divTablemain_Internalname = "TABLEMAIN";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         Gridnotifications_empowerer_Internalname = "GRIDNOTIFICATIONS_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
         subGridnotifications_Internalname = "GRIDNOTIFICATIONS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridnotifications_Allowcollapsing = 0;
         subGridnotifications_Allowselection = 0;
         subGridnotifications_Header = "";
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavSdtnotificationsdata__notificationdatetime_Jsonclick = "";
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Jsonclick = "";
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationiconclass_Jsonclick = "";
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavNotificationicon_Jsonclick = "";
         edtavNotificationicon_Enabled = 0;
         edtavNotificationicon_Format = 1;
         subGridnotifications_Class = "WorkWith";
         subGridnotifications_Backcolorstyle = 0;
         cmbavHomesampledata__productstatus_Jsonclick = "";
         cmbavHomesampledata__productstatus.Enabled = 0;
         cmbavHomesampledata__productstatus_Columnheaderclass = "";
         cmbavHomesampledata__productstatus_Columnclass = "WWColumn";
         edtavHomesampledata__productprice_Jsonclick = "";
         edtavHomesampledata__productprice_Enabled = 0;
         edtavHomesampledata__productname_Jsonclick = "";
         edtavHomesampledata__productname_Enabled = 0;
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = -1;
         edtavSdtnotificationsdata__notificationtitle_Enabled = -1;
         edtavSdtnotificationsdata__notificationiconclass_Enabled = -1;
         cmbavHomesampledata__productstatus.Enabled = -1;
         edtavHomesampledata__productprice_Enabled = -1;
         edtavHomesampledata__productname_Enabled = -1;
         lblNotificationssubtitle_Caption = "Tienes %1 nuevas notificaciones";
         Utchartcolumnline_Title = "";
         Utchartstackedbar_Title = "";
         divTablechart1_Height = 0;
         edtavCard4_value_Jsonclick = "";
         edtavCard4_value_Enabled = 1;
         edtavCard3_value_Jsonclick = "";
         edtavCard3_value_Enabled = 1;
         edtavCard2_value_Jsonclick = "";
         edtavCard2_value_Enabled = 1;
         edtavCard1_value_Jsonclick = "";
         edtavCard1_value_Enabled = 1;
         Dvpanel_tablenotifications_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Iconposition = "Right";
         Dvpanel_tablenotifications_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Title = "Notificaciones";
         Dvpanel_tablenotifications_Cls = "PanelGrayBackgroundTitle";
         Dvpanel_tablenotifications_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablenotifications_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Width = "100%";
         Dvpanel_tablechart2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart2_Iconposition = "Right";
         Dvpanel_tablechart2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart2_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart2_Title = "Sales Table";
         Dvpanel_tablechart2_Cls = "PanelFilled Panel_Danger";
         Dvpanel_tablechart2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart2_Width = "100%";
         Utchartcolumnline_Charttype = "ColumnLine";
         Utchartcolumnline_Type = "Chart";
         Utchartcolumnline_Height = "454";
         Utchartcolumnline_Objectname = "WWPBaseObjects.GetHomeSampleDataService";
         Dvpanel_tablechart1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Iconposition = "Right";
         Dvpanel_tablechart1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Title = "Task Board";
         Dvpanel_tablechart1_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tablechart1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Width = "100%";
         Utchartstackedbar_Charttype = "SmoothLine";
         Utchartstackedbar_Type = "Chart";
         Utchartstackedbar_Height = "418";
         Utchartstackedbar_Objectname = "WWPBaseObjects.GetHomeSampleDataService";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Inicio";
         subGridnotifications_Rows = 0;
         subGrid_Rows = 0;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'GRIDNOTIFICATIONS_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E13092',iparms:[{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101}]");
         setEventMetadata("GRID.LOAD",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnclass'}]}");
         setEventMetadata("GRIDNOTIFICATIONS.LOAD","{handler:'E14093',iparms:[{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129}]");
         setEventMetadata("GRIDNOTIFICATIONS.LOAD",",oparms:[{av:'edtavNotificationicon_Format',ctrl:'vNOTIFICATIONICON',prop:'Format'},{av:'AV6NotificationIcon',fld:'vNOTIFICATIONICON',pic:''}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRIDNOTIFICATIONS_FIRSTPAGE","{handler:'subgridnotifications_firstpage',iparms:[{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'GRIDNOTIFICATIONS_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129}]");
         setEventMetadata("GRIDNOTIFICATIONS_FIRSTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRIDNOTIFICATIONS_PREVPAGE","{handler:'subgridnotifications_previouspage',iparms:[{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'GRIDNOTIFICATIONS_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129}]");
         setEventMetadata("GRIDNOTIFICATIONS_PREVPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRIDNOTIFICATIONS_NEXTPAGE","{handler:'subgridnotifications_nextpage',iparms:[{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'GRIDNOTIFICATIONS_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129}]");
         setEventMetadata("GRIDNOTIFICATIONS_NEXTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRIDNOTIFICATIONS_LASTPAGE","{handler:'subgridnotifications_lastpage',iparms:[{av:'GRIDNOTIFICATIONS_nFirstRecordOnPage'},{av:'GRIDNOTIFICATIONS_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'subGridnotifications_Rows',ctrl:'GRIDNOTIFICATIONS',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:101,pic:'',hsh:true},{av:'nGXsfl_101_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:101},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_101',ctrl:'GRID',prop:'GridRC',grid:101},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:129,pic:'',hsh:true},{av:'nGXsfl_129_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:129},{av:'nRC_GXsfl_129',ctrl:'GRIDNOTIFICATIONS',prop:'GridRC',grid:129}]");
         setEventMetadata("GRIDNOTIFICATIONS_LASTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("VALIDV_GXV4","{handler:'Validv_Gxv4',iparms:[]");
         setEventMetadata("VALIDV_GXV4",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv8',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV5HomeSampleData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "UPC_ArquitecturaSistemasOP");
         AV7SDTNotificationsData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem>( context, "WWP_SDTNotificationsDataSampleItem", "UPC_ArquitecturaSistemasOP");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV14Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         AV15Parameters = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter>( context, "Parameter", "GeneXus.Reporting");
         AV16ItemClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData(context);
         AV17ItemDoubleClickData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData(context);
         AV18DragAndDropData = new GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData(context);
         AV19FilterChangedData = new GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData(context);
         AV20ItemExpandData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData(context);
         AV21ItemCollapseData = new GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData(context);
         Grid_empowerer_Gridinternalname = "";
         Gridnotifications_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         lblCard1_description_Jsonclick = "";
         lblCard1_icon_Jsonclick = "";
         lblCard2_description_Jsonclick = "";
         lblCard2_icon_Jsonclick = "";
         lblCard3_description_Jsonclick = "";
         lblCard3_icon_Jsonclick = "";
         lblCard4_description_Jsonclick = "";
         lblCard4_icon_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDvpanel_tablechart1 = new GXUserControl();
         ucUtchartstackedbar = new GXUserControl();
         ucDvpanel_tablechart2 = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
         ucDvpanel_tablenotifications = new GXUserControl();
         lblNotificationssubtitle_Jsonclick = "";
         GridnotificationsContainer = new GXWebGrid( context);
         ucGrid_empowerer = new GXUserControl();
         ucGridnotifications_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6NotificationIcon = "";
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "UPC_ArquitecturaSistemasOP");
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV12Axes = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem>( context, "WWP_SDTNotificationsDataSampleItem", "UPC_ArquitecturaSistemasOP");
         GridRow = new GXWebRow();
         GridnotificationsRow = new GXWebRow();
         lblCard4_moreinfo_Jsonclick = "";
         lblCard4_moreinfoicon_Jsonclick = "";
         lblCard3_moreinfo_Jsonclick = "";
         lblCard3_moreinfoicon_Jsonclick = "";
         lblCard2_moreinfo_Jsonclick = "";
         lblCard2_moreinfoicon_Jsonclick = "";
         lblCard1_moreinfo_Jsonclick = "";
         lblCard1_moreinfoicon_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         subGridnotifications_Linesclass = "";
         GridColumn = new GXWebColumn();
         GridnotificationsColumn = new GXWebColumn();
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCard1_value_Enabled = 0;
         edtavCard2_value_Enabled = 0;
         edtavCard3_value_Enabled = 0;
         edtavCard4_value_Enabled = 0;
         edtavHomesampledata__productname_Enabled = 0;
         edtavHomesampledata__productprice_Enabled = 0;
         cmbavHomesampledata__productstatus.Enabled = 0;
         edtavNotificationicon_Enabled = 0;
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short GRIDNOTIFICATIONS_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGridnotifications_Backcolorstyle ;
      private short edtavNotificationicon_Format ;
      private short subGrid_Backstyle ;
      private short subGridnotifications_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short subGridnotifications_Titlebackstyle ;
      private short subGridnotifications_Allowselection ;
      private short subGridnotifications_Allowhovering ;
      private short subGridnotifications_Allowcollapsing ;
      private short subGridnotifications_Collapsed ;
      private int nRC_GXsfl_101 ;
      private int nRC_GXsfl_129 ;
      private int subGrid_Rows ;
      private int subGridnotifications_Rows ;
      private int nGXsfl_101_idx=1 ;
      private int nGXsfl_129_idx=1 ;
      private int AV8Card1_Value ;
      private int edtavCard1_value_Enabled ;
      private int AV9Card2_Value ;
      private int edtavCard2_value_Enabled ;
      private int AV10Card3_Value ;
      private int edtavCard3_value_Enabled ;
      private int AV11Card4_Value ;
      private int edtavCard4_value_Enabled ;
      private int AV26GXV1 ;
      private int divTablechart1_Height ;
      private int AV30GXV5 ;
      private int subGrid_Islastpage ;
      private int subGridnotifications_Islastpage ;
      private int edtavHomesampledata__productname_Enabled ;
      private int edtavHomesampledata__productprice_Enabled ;
      private int edtavNotificationicon_Enabled ;
      private int edtavSdtnotificationsdata__notificationiconclass_Enabled ;
      private int edtavSdtnotificationsdata__notificationtitle_Enabled ;
      private int edtavSdtnotificationsdata__notificationdatetime_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int GRIDNOTIFICATIONS_nGridOutOfScope ;
      private int nGXsfl_101_fel_idx=1 ;
      private int nGXsfl_129_fel_idx=1 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGridnotifications_Backcolor ;
      private int subGridnotifications_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int subGridnotifications_Titlebackcolor ;
      private int subGridnotifications_Selectedindex ;
      private int subGridnotifications_Selectioncolor ;
      private int subGridnotifications_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRIDNOTIFICATIONS_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRIDNOTIFICATIONS_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private long GRIDNOTIFICATIONS_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_101_idx="0001" ;
      private string sGXsfl_129_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Utchartstackedbar_Objectname ;
      private string Utchartstackedbar_Height ;
      private string Utchartstackedbar_Type ;
      private string Utchartstackedbar_Charttype ;
      private string Dvpanel_tablechart1_Width ;
      private string Dvpanel_tablechart1_Cls ;
      private string Dvpanel_tablechart1_Title ;
      private string Dvpanel_tablechart1_Iconposition ;
      private string Utchartcolumnline_Objectname ;
      private string Utchartcolumnline_Height ;
      private string Utchartcolumnline_Type ;
      private string Utchartcolumnline_Charttype ;
      private string Dvpanel_tablechart2_Width ;
      private string Dvpanel_tablechart2_Cls ;
      private string Dvpanel_tablechart2_Title ;
      private string Dvpanel_tablechart2_Iconposition ;
      private string Dvpanel_tablenotifications_Width ;
      private string Dvpanel_tablenotifications_Cls ;
      private string Dvpanel_tablenotifications_Title ;
      private string Dvpanel_tablenotifications_Iconposition ;
      private string Grid_empowerer_Gridinternalname ;
      private string Gridnotifications_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablecards_Internalname ;
      private string divCard1_maintable_Internalname ;
      private string divCard1_content_Internalname ;
      private string edtavCard1_value_Internalname ;
      private string TempTags ;
      private string edtavCard1_value_Jsonclick ;
      private string lblCard1_description_Internalname ;
      private string lblCard1_description_Jsonclick ;
      private string lblCard1_icon_Internalname ;
      private string lblCard1_icon_Jsonclick ;
      private string divCard2_maintable_Internalname ;
      private string divCard2_content_Internalname ;
      private string edtavCard2_value_Internalname ;
      private string edtavCard2_value_Jsonclick ;
      private string lblCard2_description_Internalname ;
      private string lblCard2_description_Jsonclick ;
      private string lblCard2_icon_Internalname ;
      private string lblCard2_icon_Jsonclick ;
      private string divCard3_maintable_Internalname ;
      private string divCard3_content_Internalname ;
      private string edtavCard3_value_Internalname ;
      private string edtavCard3_value_Jsonclick ;
      private string lblCard3_description_Internalname ;
      private string lblCard3_description_Jsonclick ;
      private string lblCard3_icon_Internalname ;
      private string lblCard3_icon_Jsonclick ;
      private string divCard4_maintable_Internalname ;
      private string divCard4_content_Internalname ;
      private string edtavCard4_value_Internalname ;
      private string edtavCard4_value_Jsonclick ;
      private string lblCard4_description_Internalname ;
      private string lblCard4_description_Jsonclick ;
      private string lblCard4_icon_Internalname ;
      private string lblCard4_icon_Jsonclick ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Dvpanel_tablechart1_Internalname ;
      private string divTablechart1_Internalname ;
      private string Utchartstackedbar_Title ;
      private string Utchartstackedbar_Internalname ;
      private string Dvpanel_tablechart2_Internalname ;
      private string divTablechart2_Internalname ;
      private string Utchartcolumnline_Title ;
      private string Utchartcolumnline_Internalname ;
      private string Dvpanel_tablenotifications_Internalname ;
      private string divTablenotifications_Internalname ;
      private string lblNotificationssubtitle_Internalname ;
      private string lblNotificationssubtitle_Caption ;
      private string lblNotificationssubtitle_Jsonclick ;
      private string subGridnotifications_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string Gridnotifications_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationicon_Internalname ;
      private string edtavHomesampledata__productname_Internalname ;
      private string edtavHomesampledata__productprice_Internalname ;
      private string cmbavHomesampledata__productstatus_Internalname ;
      private string edtavSdtnotificationsdata__notificationiconclass_Internalname ;
      private string edtavSdtnotificationsdata__notificationtitle_Internalname ;
      private string edtavSdtnotificationsdata__notificationdatetime_Internalname ;
      private string sGXsfl_101_fel_idx="0001" ;
      private string sGXsfl_129_fel_idx="0001" ;
      private string cmbavHomesampledata__productstatus_Columnheaderclass ;
      private string cmbavHomesampledata__productstatus_Columnclass ;
      private string tblCard4_moreinfotable_Internalname ;
      private string lblCard4_moreinfo_Internalname ;
      private string lblCard4_moreinfo_Jsonclick ;
      private string lblCard4_moreinfoicon_Internalname ;
      private string lblCard4_moreinfoicon_Jsonclick ;
      private string tblCard3_moreinfotable_Internalname ;
      private string lblCard3_moreinfo_Internalname ;
      private string lblCard3_moreinfo_Jsonclick ;
      private string lblCard3_moreinfoicon_Internalname ;
      private string lblCard3_moreinfoicon_Jsonclick ;
      private string tblCard2_moreinfotable_Internalname ;
      private string lblCard2_moreinfo_Internalname ;
      private string lblCard2_moreinfo_Jsonclick ;
      private string lblCard2_moreinfoicon_Internalname ;
      private string lblCard2_moreinfoicon_Jsonclick ;
      private string tblCard1_moreinfotable_Internalname ;
      private string lblCard1_moreinfo_Internalname ;
      private string lblCard1_moreinfo_Jsonclick ;
      private string lblCard1_moreinfoicon_Internalname ;
      private string lblCard1_moreinfoicon_Jsonclick ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtavHomesampledata__productname_Jsonclick ;
      private string edtavHomesampledata__productprice_Jsonclick ;
      private string GXCCtl ;
      private string cmbavHomesampledata__productstatus_Jsonclick ;
      private string subGridnotifications_Class ;
      private string subGridnotifications_Linesclass ;
      private string edtavNotificationicon_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationiconclass_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationtitle_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationdatetime_Jsonclick ;
      private string subGrid_Header ;
      private string subGridnotifications_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablechart1_Autowidth ;
      private bool Dvpanel_tablechart1_Autoheight ;
      private bool Dvpanel_tablechart1_Collapsible ;
      private bool Dvpanel_tablechart1_Collapsed ;
      private bool Dvpanel_tablechart1_Showcollapseicon ;
      private bool Dvpanel_tablechart1_Autoscroll ;
      private bool Dvpanel_tablechart2_Autowidth ;
      private bool Dvpanel_tablechart2_Autoheight ;
      private bool Dvpanel_tablechart2_Collapsible ;
      private bool Dvpanel_tablechart2_Collapsed ;
      private bool Dvpanel_tablechart2_Showcollapseicon ;
      private bool Dvpanel_tablechart2_Autoscroll ;
      private bool Dvpanel_tablenotifications_Autowidth ;
      private bool Dvpanel_tablenotifications_Autoheight ;
      private bool Dvpanel_tablenotifications_Collapsible ;
      private bool Dvpanel_tablenotifications_Collapsed ;
      private bool Dvpanel_tablenotifications_Showcollapseicon ;
      private bool Dvpanel_tablenotifications_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_101_Refreshing=false ;
      private bool bGXsfl_129_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV101 ;
      private bool gx_BV129 ;
      private bool gx_refresh_fired ;
      private string AV6NotificationIcon ;
      private GXWebGrid GridContainer ;
      private GXWebGrid GridnotificationsContainer ;
      private GXWebRow GridRow ;
      private GXWebRow GridnotificationsRow ;
      private GXWebColumn GridColumn ;
      private GXWebColumn GridnotificationsColumn ;
      private GXUserControl ucDvpanel_tablechart1 ;
      private GXUserControl ucUtchartstackedbar ;
      private GXUserControl ucDvpanel_tablechart2 ;
      private GXUserControl ucUtchartcolumnline ;
      private GXUserControl ucDvpanel_tablenotifications ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucGridnotifications_empowerer ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavHomesampledata__productstatus ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> AV7SDTNotificationsData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem> GXt_objcol_SdtWWP_SDTNotificationsDataSample_WWP_SDTNotificationsDataSampleItem2 ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV14Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV12Axes ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerParameters_Parameter> AV15Parameters ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element AV13Axis ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemClickData AV16ItemClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemDoubleClickData AV17ItemDoubleClickData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerDragAndDropData AV18DragAndDropData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerFilterChangedData AV19FilterChangedData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemExpandData AV20ItemExpandData ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerItemCollapseData AV21ItemCollapseData ;
   }

}

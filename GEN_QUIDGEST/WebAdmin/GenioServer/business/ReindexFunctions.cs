using ExecuteQueryCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using CSGenio.persistence;
using CSGenio.business;
using CSGenio.framework;
using Quidgest.Persistence.GenericQuery;
using Quidgest.Persistence;

namespace CSGenio.business
{
    public class ReindexFunctions
    {
        public PersistentSupport sp { get; set; }
        public User user { get; set; }
        public bool Zero { get; set; }

        public ReindexFunctions(PersistentSupport sp, User user, bool Zero = false) {
            this.sp = sp;
            this.user = user;
            this.Zero = Zero;
        }   

        public void DeleteInvalidRows(CancellationToken cToken) {
            List<int> zzstateToRemove = new List<int> { 1, 11 };
            DataMatrix dm;
            sp.openConnection();

            /* --- FPVCATEGORY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcategory.FldCodcategory)
                .From(CSGenioAcategory.AreaCATEGORY)
                .Where(CriteriaSet.And().In(CSGenioAcategory.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcategory model = new CSGenioAcategory(user);
                model.ValCodcategory = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- FPVCOUNTRY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAcountry.FldCodcountry)
                .From(CSGenioAcountry.AreaCOUNTRY)
                .Where(CriteriaSet.And().In(CSGenioAcountry.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAcountry model = new CSGenioAcountry(user);
                model.ValCodcountry = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- FPVINVOICE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAinvoice.FldCodinvoice)
                .From(CSGenioAinvoice.AreaINVOICE)
                .Where(CriteriaSet.And().In(CSGenioAinvoice.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAinvoice model = new CSGenioAinvoice(user);
                model.ValCodinvoice = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- FPVITEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAitem.FldCoditem)
                .From(CSGenioAitem.AreaITEM)
                .Where(CriteriaSet.And().In(CSGenioAitem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAitem model = new CSGenioAitem(user);
                model.ValCoditem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- FPVMEM --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAmem.FldCodmem)
                .From(CSGenioAmem.AreaMEM)
                .Where(CriteriaSet.And().In(CSGenioAmem.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAmem model = new CSGenioAmem(user);
                model.ValCodmem = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserLogin --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioApsw.FldCodpsw)
                .From(CSGenioApsw.AreaPSW)
                .Where(CriteriaSet.And().In(CSGenioApsw.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioApsw model = new CSGenioApsw(user);
                model.ValCodpsw = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcess --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_apr.FldCodascpr)
                .From(CSGenioAs_apr.AreaS_APR)
                .Where(CriteriaSet.And().In(CSGenioAs_apr.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_apr model = new CSGenioAs_apr(user);
                model.ValCodascpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationEmailSignature --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nes.FldCodsigna)
                .From(CSGenioAs_nes.AreaS_NES)
                .Where(CriteriaSet.And().In(CSGenioAs_nes.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nes model = new CSGenioAs_nes(user);
                model.ValCodsigna = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- NotificationMessage --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_nm.FldCodmesgs)
                .From(CSGenioAs_nm.AreaS_NM)
                .Where(CriteriaSet.And().In(CSGenioAs_nm.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_nm model = new CSGenioAs_nm(user);
                model.ValCodmesgs = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- FPVBRAND --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAbrand.FldCodbrand)
                .From(CSGenioAbrand.AreaBRAND)
                .Where(CriteriaSet.And().In(CSGenioAbrand.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAbrand model = new CSGenioAbrand(user);
                model.ValCodbrand = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessArgument --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_arg.FldCodargpr)
                .From(CSGenioAs_arg.AreaS_ARG)
                .Where(CriteriaSet.And().In(CSGenioAs_arg.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_arg model = new CSGenioAs_arg(user);
                model.ValCodargpr = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- AsyncProcessAttachments --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_pax.FldCodpranx)
                .From(CSGenioAs_pax.AreaS_PAX)
                .Where(CriteriaSet.And().In(CSGenioAs_pax.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_pax model = new CSGenioAs_pax(user);
                model.ValCodpranx = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- UserAuthorization --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAs_ua.FldCodua)
                .From(CSGenioAs_ua.AreaS_UA)
                .Where(CriteriaSet.And().In(CSGenioAs_ua.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAs_ua model = new CSGenioAs_ua(user);
                model.ValCodua = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- FPVSTORE --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAstore.FldCodstore)
                .From(CSGenioAstore.AreaSTORE)
                .Where(CriteriaSet.And().In(CSGenioAstore.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAstore model = new CSGenioAstore(user);
                model.ValCodstore = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                

            /* --- FPVSUBCATEGORY --- */
            dm = sp.Execute(
                new SelectQuery()
                .Select(CSGenioAsubcategory.FldCodsubcategory)
                .From(CSGenioAsubcategory.AreaSUBCATEGORY)
                .Where(CriteriaSet.And().In(CSGenioAsubcategory.FldZzstate, zzstateToRemove))
                );

            for (int i = 0; i < dm.NumRows; i++)
            {
                CSGenioAsubcategory model = new CSGenioAsubcategory(user);
                model.ValCodsubcategory = dm.GetKey(i, 0);

                try
                {
                    model.delete(sp);
                }
                //Not every exception should be allowed to continue record deletion, only business exceptions need to be caught and allow to deletion continue.
                //If there are other types of exceptions, such as database connection problems, for example, execution should be stopped immediately
                catch(BusinessException ex)
                {
                    Log.Error((ex.UserMessage != null) ? ex.UserMessage : ex.Message);
                }
            }
                
            
            //Hard Coded Tabels
            //These can be directly removed

            /* --- FPVmem --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVmem")
                .Where(CriteriaSet.And().In("FPVmem", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVcfg")
                .Where(CriteriaSet.And().In("FPVcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVlstusr --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVlstusr")
                .Where(CriteriaSet.And().In("FPVlstusr", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVlstcol --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVlstcol")
                .Where(CriteriaSet.And().In("FPVlstcol", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVlstren --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVlstren")
                .Where(CriteriaSet.And().In("FPVlstren", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVusrwid --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVusrwid")
                .Where(CriteriaSet.And().In("FPVusrwid", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVusrcfg --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVusrcfg")
                .Where(CriteriaSet.And().In("FPVusrcfg", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVusrset --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVusrset")
                .Where(CriteriaSet.And().In("FPVusrset", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVwkfact --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVwkfact")
                .Where(CriteriaSet.And().In("FPVwkfact", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVwkfcon --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVwkfcon")
                .Where(CriteriaSet.And().In("FPVwkfcon", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVwkflig --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVwkflig")
                .Where(CriteriaSet.And().In("FPVwkflig", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVwkflow --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVwkflow")
                .Where(CriteriaSet.And().In("FPVwkflow", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVnotifi --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVnotifi")
                .Where(CriteriaSet.And().In("FPVnotifi", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVprmfrm --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVprmfrm")
                .Where(CriteriaSet.And().In("FPVprmfrm", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVscrcrd --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVscrcrd")
                .Where(CriteriaSet.And().In("FPVscrcrd", "ZZSTATE", zzstateToRemove)));
                
            /* --- docums --- */
            sp.Execute(new DeleteQuery()
                .Delete("docums")
                .Where(CriteriaSet.And().In("docums", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVpostit --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVpostit")
                .Where(CriteriaSet.And().In("FPVpostit", "ZZSTATE", zzstateToRemove)));
                
            /* --- hashcd --- */
            sp.Execute(new DeleteQuery()
                .Delete("hashcd")
                .Where(CriteriaSet.And().In("hashcd", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPValerta --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPValerta")
                .Where(CriteriaSet.And().In("FPValerta", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPValtent --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPValtent")
                .Where(CriteriaSet.And().In("FPValtent", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVtalert --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVtalert")
                .Where(CriteriaSet.And().In("FPVtalert", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVdelega --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVdelega")
                .Where(CriteriaSet.And().In("FPVdelega", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVTABDINAMIC --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVTABDINAMIC")
                .Where(CriteriaSet.And().In("FPVTABDINAMIC", "ZZSTATE", zzstateToRemove)));
                
            /* --- UserAuthorization --- */
            sp.Execute(new DeleteQuery()
                .Delete("UserAuthorization")
                .Where(CriteriaSet.And().In("UserAuthorization", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPValtran --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPValtran")
                .Where(CriteriaSet.And().In("FPValtran", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVworkflowtask --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVworkflowtask")
                .Where(CriteriaSet.And().In("FPVworkflowtask", "ZZSTATE", zzstateToRemove)));
                
            /* --- FPVworkflowprocess --- */
            sp.Execute(new DeleteQuery()
                .Delete("FPVworkflowprocess")
                .Where(CriteriaSet.And().In("FPVworkflowprocess", "ZZSTATE", zzstateToRemove)));
                

            sp.closeConnection();
        }





        // USE /[MANUAL RDX_STEP]/
    }
}
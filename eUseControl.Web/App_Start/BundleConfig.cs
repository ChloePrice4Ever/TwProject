using System.Web.Optimization;

namespace eUseControl.Web
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS Files //
            bundles.Add(new StyleBundle("~/bundles/animation.min/css").Include(
                      "~/Content/animate.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/aos/css").Include(
                      "~/Content/aos.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap.min/css").Include(
                      "~/Content/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap-icons/css").Include(
                      "~/Content/bootstrap-icons.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/boxicons.min/css").Include(
                      "~/Content/boxicons.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/glightbox.min/css").Include(
                      "~/Content/glightbox.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/swiper-bundle.min/css").Include(
                      "~/Content/swiper-bundle.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/style/css").Include(
                      "~/Content/style.css", new CssRewriteUrlTransform()));
         


            // JS Files //
            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                      "~/Scripts/main.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/aos/js").Include(
                      "~/Scripts/aos.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap.bundle.min/js").Include(
                      "~/Scripts/bootstrap.bundle.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/glightbox.min/js").Include(
                      "~/Scripts/glightbox.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/isotope.pkgd.min/js").Include(
                      "~/Scripts/isotope.pkgd.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/swiper-bundle.min/js").Include(
                      "~/Scripts/swiper-bundle.min.js", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/validate/js").Include(
                      "~/Scripts/validate.js", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/app/css").Include(
                "~/Content/assets/css/bootstrap.min.css",
                "~/Content/assets/css/icons.min.css",
                "~/Content/assets/css/app.min.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/footer/css").Include(
                "~/Content/assets/css/footer/footer.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/footable/css").Include(
                "~/Content/assets/css/footable.core.min.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/product/css").Include(
                "~/Content/assets/css/dropzone.min.css",
                "~/Content/assets/css/select2.min.css",
                "~/Content/assets/css/bootstrap-select.min.css"
            ));

            bundles.Add(new StyleBundle("~/bundles/products/css").Include(
                "~/Content/assets/css/magnific-popup.css"
            ));

            /*JS*/
            bundles.Add(new ScriptBundle("~/bundles/vendor/js").Include(
    "~/Content/assets/js/vendor.min.js"
));

            bundles.Add(new ScriptBundle("~/bundles/app/js").Include(
                "~/Content/assets/js/app.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/dashboard/js").Include(
                "~/Content/assets/js/jquery.knob.min.js",
                "~/Content/assets/js/jquery.peity.min.js",
                "~/Content/assets/js/jquery.sparkline.min.js",
                "~/Content/assets/js/dashboard-1.init.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/footable/js").Include(
                "~/Content/assets/js/footable.all.min.js",
                "~/Content/assets/js/foo-tables.init.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/product/js").Include(
                "~/Content/assets/js/dropzone.min.js",
                "~/Content/assets/js/form-fileuploads.init.js",
                "~/Content/assets/js/parsley.min.js",
                "~/Content/assets/js/form-validation.init.js",
                "~/Content/assets/js/jquery.multi-select.js",
                "~/Content/assets/js/select2.min.js",
                "~/Content/assets/js/bootstrap-select.min.js",
                "~/Content/assets/js/jquery.bootstrap-touchspin.min.js",
                "~/Content/assets/js/form-advanced.init.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/products/js").Include(
                "~/Content/assets/js/jquery.magnific-popup.min.js",
                "~/Content/assets/js/gallery.init.js"
            ));



        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;


namespace TweebaaWebApp2.design.templates
{
    /// <summary>
    /// Summary description for ProductDesigner
    /// </summary>
    public class ProductDesigner : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            StringBuilder strMenu = new StringBuilder();

	        strMenu.Append("</div>");
            strMenu.Append("</section>");

            strMenu.Append("<!-- SUB-BAR -->");
            strMenu.Append("<section class=\"fpd-sub-bar fpd-clearfix\">");

	        strMenu.Append("<!-- Left -->");
	        strMenu.Append("<div class=\"fpd-left\">");
            strMenu.Append("<div class=\"fpd-btn fpd-tooltip\" data-context=\"layers\" title=\"Manage Elements\">");
            strMenu.Append("<i class=\"fpd-icon-layers\"></i><span>MANAGE</span>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-undo fpd-btn fpd-disabled fpd-tooltip\" title=\"Undo\">");
			strMenu.Append("<i class=\"fpd-icon-undo\"></i>");
		    strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-redo fpd-btn fpd-disabled fpd-tooltip\" title=\"Redo\">");
			strMenu.Append("<i class=\"fpd-icon-redo\"></i>");
		    strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-reset-product fpd-btn fpd-tooltip\" title=\"Reset Collage\">");
			strMenu.Append("<i class=\"fpd-icon-reset\"></i>");
		    strMenu.Append("</div>");
	        strMenu.Append("</div>");

	        strMenu.Append("<!-- Right -->");
	        strMenu.Append("<div class=\"fpd-right\">");

            strMenu.Append("<div class=\"fpd-zoom fpd-option-group\">");
            strMenu.Append("<div class=\"fpd-btn fpd-tooltip\" title=\"Zoom\">");
            strMenu.Append("<i class=\"fpd-icon-zoom-in\"></i>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-option-content\">");
            strMenu.Append("<div data-value=\"1\" data-min=\"1\" data-max=\"3\" data-step=\"0.2\" class=\"fpd-set-zoom fpd-slider\"></div>");
                     
            strMenu.Append("<div class=\"fpd-stage-pan fpd-btn fpd-tooltip\" title=\"Pan\">");
	    strMenu.Append("<i class=\"fpd-icon-drag\"></i>");
	    strMenu.Append("</div>");

            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-more fpd-btn fpd-dropdown\" >");
            strMenu.Append("<i class=\"fpd-icon-more\" title=\"More\"></i>");
            strMenu.Append("<div class=\"fpd-dropdown-menu fpd-shadow-1  fpd-scale-tr\">");
            strMenu.Append("<span class=\"fpd-download-image fpd-btn fpdmg\">Publish</span>");//Download Image
            strMenu.Append("<span class=\"fpd-save-product fpd-btn fpdmg\">Save Draft</span>");//Download PDF
            strMenu.Append("<span class=\"fpd-load-saved-products fpd-btn fpdmg\">Load Draft</span>");//Print
            strMenu.Append("</div>");
	        strMenu.Append("</div>");

            strMenu.Append("</section>");

            strMenu.Append("<!-- MAIN CONTAINER -->");
            strMenu.Append("<section class=\"fpd-main-container\">");

	        strMenu.Append("<!-- Product Stage -->");
	        strMenu.Append("<div class=\"fpd-product-stage\">");
		    strMenu.Append("<canvas></canvas>");

		    strMenu.Append("<div class=\"fpd-element-tooltip\"></div>");
	        strMenu.Append("</div>");

	        strMenu.Append("<!-- Context Dialog -->");
	        strMenu.Append("<div class=\"fpd-context-dialog fpd-shadow-2 fpd-columns-3\" data-columns=\"3\">");
		    strMenu.Append("<nav class=\"fpd-dialog-head fpd-clearfix fpd-primary-bg-color fpd-primary-text-color\">");
			strMenu.Append("<div class=\"fpd-left fpd-dialog-drag-handle\">");
			strMenu.Append("<div><i class=\"fpd-icon-drag\"></i><span class=\"fpd-dialog-title\"></span></div>");
			strMenu.Append("</div>");
			strMenu.Append("<div class=\"fpd-right\">");
			strMenu.Append("<div class=\"fpd-content-back fpd-btn\">");
			strMenu.Append("<i class=\"fpd-icon-back\"></i>");
			strMenu.Append("</div>");
			strMenu.Append("<div class=\"fpd-close-dialog fpd-btn\">");
			strMenu.Append("<i class=\"fpd-icon-close\"></i>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
		    strMenu.Append("</nav>");
		    strMenu.Append("<div class=\"fpd-dialog-content\">");

			strMenu.Append("<!-- Manage Layers -->");
			strMenu.Append("<div class=\"fpd-content-layers\">");
			strMenu.Append("<div class=\"fpd-list\"></div>");
			strMenu.Append("</div>");

			strMenu.Append("<!-- Edit Element -->");
			strMenu.Append("<div class=\"fpd-content-edit\">");
			strMenu.Append("<div class=\"fpd-list\">");

			strMenu.Append("<!-- Fill Options -->");
			strMenu.Append("<div class=\"fpd-fill-options fpd-head-options fpd-list-row\">");
			strMenu.Append("<div class=\"fpd-cell-full\">");
            strMenu.Append("<label>Fill Options</label>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
			strMenu.Append("<div class=\"fpd-fill-options fpd-sub-option fpd-list-row fpd-color-option\">");
			strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Color</label>");
			strMenu.Append("</div>");
			strMenu.Append("<div class=\"fpd-cell-1\">");
			strMenu.Append("<div class=\"fpd-color-picker\">");
			strMenu.Append("<input type=\"text\" value=\"\">");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
            
            
			strMenu.Append("<div class=\"fpd-fill-options fpd-sub-option fpd-list-row fpd-patterns-option\">");
			strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Patterns</label>");
			strMenu.Append("</div>");
			strMenu.Append("<div class=\"fpd-cell-1\">");
			strMenu.Append("<div class=\"fpd-patterns\">");
			strMenu.Append("<div class=\"fpd-grid fpd-grid-contain\"></div>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
			strMenu.Append("<div class=\"fpd-fill-options fpd-sub-option fpd-list-row fpd-opacity-option\">");
			strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Opacity</label>");
			strMenu.Append("</div>");
			strMenu.Append("<div class=\"fpd-cell-1\">");
			strMenu.Append("<div>");
			strMenu.Append("<div data-value=\"0.5\" data-min=\"0\" data-max=\"1\" data-step=\"0.01\" class=\"fpd-opacity-slider fpd-slider\"></div>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");

			strMenu.Append("<!-- Filter Options -->");
			strMenu.Append("<div class=\"fpd-filter-options fpd-head-options fpd-list-row\">");
			strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Filter</label>");
			strMenu.Append("</div>");
			strMenu.Append("<div class=\"fpd-cell-1\">");
			strMenu.Append("<div class=\"fpd-grid fpd-grid-cover\">");
			strMenu.Append("<div class=\"fpd-filter-no fpd-item\" data-filter=\"no\"><picture></picture></div>");
			strMenu.Append("<div class=\"fpd-filter-grayscale fpd-item\" data-filter=\"grayscale\"><picture></picture></div>");
			strMenu.Append("<div class=\"fpd-filter-sepia fpd-item\" data-filter=\"sepia\"><picture></picture></div>");
			strMenu.Append("<div class=\"fpd-filter-sepia2 fpd-item\" data-filter=\"sepia2\"><picture></picture></div>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");

			strMenu.Append("<!-- Text Options -->");
			strMenu.Append("<div class=\"fpd-text-options fpd-head-options fpd-list-row\">");
			strMenu.Append("<div class=\"fpd-cell-full\">");
            strMenu.Append("<label>Text Options</label>");
			strMenu.Append("</div>");
			strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-text-options fpd-sub-option fpd-list-row fpd-text-option\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Change Text</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<textarea class=\"fpd-change-text fpd-border-color\"></textarea>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-text-options fpd-sub-option fpd-list-row fpd-typeface-option\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Typeface</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div>");
            strMenu.Append("<select class=\"fpd-fonts-dropdown\"></select>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-text-options fpd-sub-option fpd-list-row fpd-lineHeight-option\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Line Height</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div>");
            strMenu.Append("<div data-value=\"1\" data-min=\"0.1\" data-max=\"10\" data-step=\"0.1\" class=\"fpd-line-height-slider fpd-slider\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-text-options fpd-sub-option fpd-list-row fpd-textAlignment-option\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Alignment</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div class=\"fpd-set-alignment\">");
            strMenu.Append("<span title=\"Align Left\" class=\"fpd-text-align-left fpd-btn fpd-tooltip\"><i class=\" fpd-icon-format-align-left\"></i></span>");
            strMenu.Append("<span title=\"Align Center\" class=\"fpd-text-align-center fpd-btn fpd-tooltip\"><i class=\" fpd-icon-format-align-center\"></i></span>");
            strMenu.Append("<span title=\"Align Right\" class=\"fpd-text-align-right fpd-btn fpd-tooltip\"><i class=\" fpd-icon-format-align-right\"></i></span>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-text-options fpd-sub-option fpd-list-row fpd-textStyle-option\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Styling</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div class=\"fpd-set-style\">");
            strMenu.Append("<span title=\"Bold\" class=\"fpd-text-style-bold fpd-btn fpd-tooltip\"><i class=\" fpd-icon-format-bold\"></i></span>");
            strMenu.Append("<span title=\"Italic\" class=\"fpd-text-style-italic fpd-btn fpd-tooltip\"><i class=\" fpd-icon-format-italic\"></i></span>");
            strMenu.Append("<span title=\"Underline\" class=\"fpd-text-style-underline fpd-btn fpd-tooltip\"><i class=\" fpd-icon-format-underline\"></i></span>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("<!-- Curved Text Options -->");
            strMenu.Append("<div class=\"fpd-text-options fpd-curved-text-options fpd-sub-option fpd-list-row\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Curved Text</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div>");
            strMenu.Append("<div class=\"fpd-curved-text-switcher fpd-switch-container\">");
            strMenu.Append("<div class=\"fpd-switch-bar\"></div>");
            strMenu.Append("<div class=\"fpd-switch-toggle\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-text-options fpd-curved-text-options fpd-sub-option fpd-sub-2 fpd-list-row\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Radius</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div>");
            strMenu.Append("<div data-value=\"100\" data-min=\"0\" data-max=\"200\" data-step=\"1\" class=\"fpd-curved-text-radius-slider fpd-slider\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-text-options fpd-curved-text-options fpd-sub-option fpd-sub-2 fpd-list-row\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Spacing</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div>");
            strMenu.Append("<div data-value=\"50\" data-min=\"0\" data-max=\"100\" data-step=\"1\" class=\"fpd-curved-text-spacing-slider fpd-slider\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-text-options fpd-curved-text-options fpd-sub-option fpd-sub-2 fpd-list-row\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Reverse</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div>");
            strMenu.Append("<div class=\"fpd-curved-text-reverse-switcher fpd-switch-container\">");
            strMenu.Append("<div class=\"fpd-switch-bar\"></div>");
            strMenu.Append("<div class=\"fpd-switch-toggle\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("<!-- Transform Options -->");
            strMenu.Append("<div class=\"fpd-transform-options fpd-head-options fpd-list-row\">");
            strMenu.Append("<div class=\"fpd-cell-full\">");
            strMenu.Append("<label>Transform</label>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-transform-options fpd-list-row fpd-sub-option fpd-angle-option\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Angle</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div>");
            strMenu.Append("<div data-value=\"0\" data-min=\"0\" data-max=\"359\" data-step=\"1\" class=\"fpd-angle-slider fpd-slider\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-transform-options fpd-list-row fpd-sub-option fpd-scale-option\">");
            strMenu.Append("<div class=\"fpd-cell-0\">");
            strMenu.Append("<label>Scale</label>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-cell-1\">");
            strMenu.Append("<div>");
            strMenu.Append("<div data-value=\"1\" data-min=\"0.1\" data-max=\"5\" data-step=\"0.1\" class=\"fpd-scale-slider fpd-slider\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("<!-- Helper Buttons -->");
            strMenu.Append("<div class=\"fpd-helper-btns fpd-list-row\">");
            strMenu.Append("<div class=\"fpd-cell-full\">");
            strMenu.Append("<div>");
            strMenu.Append("<span class=\"fpd-moveLayer-options\">");
            strMenu.Append("<span title=\"Bring Back\" class=\"fpd-move-up fpd-btn fpd-tooltip\">");
            strMenu.Append("<i class=\"fpd-icon-move-up\"></i>");
            strMenu.Append("</span>");
            strMenu.Append("<span title=\"Send Foward\" class=\"fpd-move-down fpd-btn fpd-tooltip\">");
            strMenu.Append("<i class=\"fpd-icon-move-down\"></i>");
            strMenu.Append("</span>");
            strMenu.Append("</span>");
            strMenu.Append("<span class=\"fpd-alignment-options\">");
            strMenu.Append("<span title=\"Center Horizontal\" class=\"fpd-center-horizontal fpd-btn fpd-tooltip\">");
            strMenu.Append("<i class=\"fpd-icon-align-horizontal\"></i>");
            strMenu.Append("</span>");
            strMenu.Append("<span title=\"Center Vertical\" class=\"fpd-center-vertical fpd-btn fpd-tooltip\">");
            strMenu.Append("<i class=\"fpd-icon-align-vertical\"></i>");
            strMenu.Append("</span>");
            strMenu.Append("</span>");
            strMenu.Append("<span class=\"fpd-flip-options\">");
            strMenu.Append("<span title=\"Flip Horizonta\" class=\"fpd-flip-horizontal fpd-btn fpd-tooltip\">");
            strMenu.Append("<i class=\"fpd-icon-flip-horizontal\"></i>");
            strMenu.Append("</span>");
            strMenu.Append("<span title=\"Flip Vertical\" class=\"fpd-flip-vertical fpd-btn fpd-tooltip\">");
            strMenu.Append("<i class=\"fpd-icon-flip-vertical \"></i>");
            strMenu.Append("</span>");
            strMenu.Append("</span>");
            strMenu.Append("<span title=\"Reset To His Origin\" class=\"fpd-reset-element fpd-btn fpd-tooltip\">");
            strMenu.Append("<i class=\"fpd-icon-reset\"></i>");
            strMenu.Append("</span>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("<!-- Add Something -->");
            strMenu.Append("<div class=\"fpd-content-adds\">");
            strMenu.Append("");

            strMenu.Append("<!-- Choose add option -->");
            strMenu.Append("<div class=\"fpd-choose-add\">");
            strMenu.Append("<div class=\"fpd-add-image fpd-btn-raised fpd-secondary-bg-color fpd-secondary-text-color\">");
            strMenu.Append("<i class=\"fpd-icon-file-upload\"></i><span>Add your own Image</span>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-add-text fpd-btn-raised fpd-secondary-bg-color fpd-secondary-text-color\">");
            strMenu.Append("<i class=\"fpd-icon-text-format\"></i><span>Add your own text</span>");
            strMenu.Append("<div class=\"fpd-input-text fpd-clearfix fpd-trans\">");
            strMenu.Append("<input type=\"text\" placeholder=\"Enter your text\" />");
            strMenu.Append("<span class=\"fpd-btn\"><i class=\"fpd-icon-done\"></i></span>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-add-facebook-photo fpd-btn-raised fpd-secondary-bg-color fpd-secondary-text-color\">");
            strMenu.Append("<i class=\"fpd-icon-facebook\"></i><span>Add photo from facebook</span>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-add-instagram-photo fpd-btn-raised fpd-secondary-bg-color fpd-secondary-text-color\">");
            strMenu.Append("<i class=\"fpd-icon-instagram\"></i><span>Add photo from instagram</span>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-add-design fpd-btn-raised fpd-secondary-bg-color fpd-secondary-text-color\">");
            strMenu.Append("<i class=\"fpd-icon-design-library\"></i><span>Choose from Designs</span>");
            strMenu.Append("</div>");
            strMenu.Append("<form class=\"fpd-upload-form\" style=\"display: block;\">");
            strMenu.Append("<input type=\"file\" class=\"fpd-input-image\" name=\"uploaded_file\" style=\"position:absolute;left:-9999999px;visibility:hidden;\"  />");
            strMenu.Append("</form>");
            strMenu.Append("");
            strMenu.Append("<!-- Facebook Wrapper -->");
            strMenu.Append("<div class=\"fpd-add-facebook-photo-wrapper fpd-content-sub\" data-subContext=\"facebook\">");
            strMenu.Append("<div class=\"fpd-content-head fpd-clearfix\">");
            strMenu.Append("<fb:login-button data-max-rows=\"1\" data-show-faces=\"false\" data-scope=\"user_photos\" autologoutlink=\"true\"></fb:login-button>");
            strMenu.Append("<select class=\"fpd-fb-user-albums\" data-placeholder=\"Select an album\">");
            strMenu.Append("</select>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-content-main\">");
            strMenu.Append("<div class=\"fpd-grid fpd-grid-cover fpd-photo-grid fpd-dynamic-columns\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("<!-- Instagram Wrapper -->");
            strMenu.Append("<div class=\"fpd-add-instagram-photo-wrapper fpd-content-sub\" data-subContext=\"instagram\">");
            strMenu.Append("<div class=\"fpd-tabs fpd-primary-bg-color fpd-primary-text-color\">");
            strMenu.Append("<span class=\"fpd-insta-feed fpd-btn\">My Feed</span>");
            strMenu.Append("<span class=\"fpd-insta-recent-images fpd-btn\">My Recent Images</span>");
            strMenu.Append("</div>");
            strMenu.Append("<div class=\"fpd-content-main\">");
            strMenu.Append("<div class=\"fpd-grid fpd-grid-cover fpd-photo-grid fpd-dynamic-columns\"></div>");
            strMenu.Append("");
            strMenu.Append("</div>");
            strMenu.Append("<span class=\"fpd-insta-load-next fpd-btn fpd-disabled\">");
            strMenu.Append("<i class=\"fpd-icon-more-horizontal\"></i>");
            strMenu.Append("</span>");
            strMenu.Append("");
            strMenu.Append("</div>");

            strMenu.Append("<!-- Designs Wrapper -->");
            strMenu.Append("<div class=\"fpd-add-design-wrapper fpd-content-sub\" data-subContext=\"designs\">");
            strMenu.Append("<div class=\"fpd-content-head\"></div>");
            strMenu.Append("<div class=\"fpd-content-main\">");
            strMenu.Append("<div class=\"fpd-grid fpd-grid-contain fpd-padding fpd-dynamic-columns\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("<!-- Products -->");
            strMenu.Append("<div class=\"fpd-content-products\">");
            strMenu.Append("<div class=\"fpd-content-head\"></div>");
            strMenu.Append("<div class=\"fpd-content-main\">");
            strMenu.Append("<div class=\"fpd-grid fpd-grid-contain fpd-padding fpd-dynamic-columns\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("<!-- Saved Products -->");
            strMenu.Append("<div class=\"fpd-content-saved-products\">");
            strMenu.Append("<div class=\"fpd-grid fpd-grid-contain fpd-padding fpd-dynamic-columns\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("<!-- Loader -->");
            strMenu.Append("<div class=\"fpd-context-loader\">");
            strMenu.Append("<div class=\"fpd-loading\"></div>");
            strMenu.Append("</div>");
            strMenu.Append("</div>");

            strMenu.Append("</div>");
            strMenu.Append("");
            strMenu.Append("</section>");
            strMenu.Append("");
            strMenu.Append("<!-- Full Loader -->");
            strMenu.Append("<div class=\"fpd-full-loader\">");
            strMenu.Append("<div class=\"fpd-loading\"></div>");
            strMenu.Append("</div>");
            context.Response.Write(strMenu.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
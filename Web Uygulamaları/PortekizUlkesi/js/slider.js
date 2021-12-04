$(document).ready(function(){
	
			generate_image_slider("#image_slider_1",2000);
	
			function generate_image_slider(slider_id,automove_timer){
	
				var pager_html = "";
				var slider_screen = 1;
				var element_width = $(slider_id).width();
				var element_count = $(slider_id).find(".image_slider_element").length;
				var max_element_count = Math.floor((element_width - 200) / 20);
	
				$(slider_id).find(".image_slider_body_container").css("width",(element_width * element_count)+"px");
				$(slider_id).find(".image_slider_element").css("width",element_width+"px");
	
				if(element_count <= max_element_count){
	
					$(slider_id).find(".image_slider_pager").css("width",((element_count * 20) - 5)+"px");
	
					for (i = 1; i <= element_count; i++) {
						pager_html+="<div class='image_slider_pager_element' pager-element-id='"+i+"'></div>";
					}
	
					$(slider_id).find(".image_slider_pager").html(pager_html).show();
	
					activate_image_slider_pager_element(slider_id,slider_screen);
	
				}
	
				if(element_count > 1){
	
					$(slider_id).find(".image_slider_right").show();
	
					// pager elemente tıklanınca gerçekleşecek olaylar
					$(slider_id).on("click",".image_slider_pager_element",function(){
	
						slider_screen = $(this).attr("pager-element-id");
						slider_screen = animate_image_slider(slider_id,slider_screen,element_count,element_width);
	
					});
					// pager elemente tıklanınca gerçekleşecek olaylar
	
					// sol oka tıklanınca gerçekleşecek olaylar
					$(slider_id).on("click",".image_slider_left",function(){
	
						slider_screen--;
						slider_screen = animate_image_slider(slider_id,slider_screen,element_count,element_width);
	
					});
					// sol oka tıklanınca gerçekleşecek olaylar
	
					// sağ oka tıklanınca gerçekleşecek olaylar
					$(slider_id).on("click",".image_slider_right",function(){
	
						slider_screen++;
						slider_screen = animate_image_slider(slider_id,slider_screen,element_count,element_width);
	
					});
					// sağ oka tıklanınca gerçekleşecek olaylar
	
					// automove
					if(automove_timer > 0){
	
						var image_slider_interval_timer;
	
						function image_slider_interval() {
	
							image_slider_interval_timer = setInterval(function() {
	
								slider_screen++;
								slider_screen = animate_image_slider(slider_id,slider_screen,element_count,element_width);
	
							}, automove_timer);
	
						}
	
						$(slider_id).on("mouseenter",".image_slider_body, .image_slider_left, .image_slider_right, .image_slider_pager",function(ev){
							clearInterval(image_slider_interval_timer);
						});
	
						$(slider_id).on("mouseleave",function(ev){
							image_slider_interval();
						});
	
						image_slider_interval();
					}
					// automove
	
				}
	
			}
	
			function animate_image_slider(slider_id,slider_screen,element_count,element_width){
	
				if(slider_screen < 1 || slider_screen > element_count){
					slider_screen = 1;
				}
	
				$(slider_id).find(".image_slider_left, .image_slider_right").show();
	
				if(slider_screen == 1){
					$(slider_id).find(".image_slider_left").hide();
				}else if(slider_screen == element_count){
					$(slider_id).find(".image_slider_right").hide();
				}
	
				$(slider_id).find(".image_slider_body_container").animate({
					left: -(slider_screen-1)*element_width+"px"
				},250);
	
				activate_image_slider_pager_element(slider_id,slider_screen);
	
				return slider_screen;
	
			}
	
			function activate_image_slider_pager_element(slider_id,element_id){
	
				if($(slider_id).find(".image_slider_pager").is(':visible')) {
					$(slider_id).find(".image_slider_pager_element").removeClass("image_slider_pager_element_active");
					$(slider_id).find(".image_slider_pager_element[pager-element-id='"+element_id+"']").addClass("image_slider_pager_element_active");
				}
	
			}
	
		});
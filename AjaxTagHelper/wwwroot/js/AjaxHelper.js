
"use-strict";

var elementActions = document.querySelectorAll(".ajaxAction");
   
for (let i = 0; i < elementActions.length; i++) {
    elementActions[i].classList.remove("ajaxAction");
    elementActions[i].addEventListener("click",
        function (e) {
                e.preventDefault();
                let el = e.currentTarget;
                let ajaxAction = el.getAttribute("action");
                let ajaxMethod = el.getAttribute("data-method");
                let ajaxFailureFunction = el.getAttribute("failure-func");
                let ajaxSuccessFunction = el.getAttribute("success-func");
                let ajaxContentType = el.getAttribute("data-content-type");
                let ajaxDataId = el.getAttribute("data-id");
                let ajaxDataArea = el.getAttribute("data-area");
                $.ajax({
                    url:"./"+ajaxDataArea + ajaxAction,
                    type: ajaxMethod,
                    //contentType:ajaxContentType,
                    data: { id: ajaxDataId },
                    success: function(data) {  
                        if (ajaxSuccessFunction !== "") {
                            window[ajaxSuccessFunction](data);
                        } else {
                            alert("success");
                        }
                    },
                    error: function(data) {
                        if (ajaxFailureFunction !== "") {
                            window[ajaxFailureFunction](data);
                        } else {
                            alert("Error");
                        }

                    }
                });
                
            });
}

var elements = document.querySelectorAll(".ajaxButton");
for (let i = 0; i < elements.length; i++) {
      elements[i].classList.remove("ajaxButton");
      elements[i].addEventListener("click",
          function (e) {
             
              let el = e.currentTarget;
              let ajaxAction = el.getAttribute("action");
              let ajaxMethod = el.getAttribute("data-method");
              let ajaxFailureFunction = el.getAttribute("failure-func");
              let ajaxSuccessFunction = el.getAttribute("success-func");
              let ajaxContentType = el.getAttribute("data-content-type");
              let ajaxFormId = el.getAttribute("form-id");
              let ajaxDataArea = el.getAttribute("data-area");
              let formData = {};
              $("#"+ajaxFormId).find("input[name]").each(function (index, node) {
                  formData[node.name] = node.value;
                  node.value=null;
              });
              $.ajax({
                  url:"./"+ajaxDataArea + ajaxAction,
                  type: ajaxMethod,
                  //contentType:ajaxContentType,
                  data: formData,
                  success: function (data) {          
                      if (ajaxSuccessFunction !== "") {
                          window[ajaxSuccessFunction](data);
                      } else {
                          alert("success");
                      }
                  },
                  error: function (data) {
                      if (ajaxFailureFunction !== "") {
                          failureFunc(data);
                      } else {
                          alert("Error");
                      }

                  }
              });

          });
  }





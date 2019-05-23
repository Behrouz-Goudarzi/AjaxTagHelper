# AjaxTagHelper
A simple solution to using links and ajax forms using Tag Helper in aspnet core


First, copy the AjaxTagHelper class from the Extensions folder to your project.


Second, copy the AjaxTagHelper.js file from js folder in wwwroot and add it to your project.


Then do the following:
Open the viewImports file and add the following code

    @using AjaxTagHelper.Extensions
    @using AjaxTagHelper
    @using AjaxTagHelper.Models
    @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
    @addTagHelper *, AjaxTagHelper
 
 To use Action Ajax, add the following code instead of the <a> tag.
 
            <ajax-action ajax-action="Delete" ajax-controller="Home" ajax-data-id="@Model.Id"
                         class="btn btn-danger btn-sm" ajax-success-func="SuccessDelete">
                Delete
            </ajax-action>

Use the following code to use AJAX to send the form to server.

        <div class="row">
            <form id="frmCreate" class="col-sm-9">
                <div class="row">
                    <div class="col-sm-4 form-control">
                        <input placeholder="Enter Name" name="Name" class="input-group" type="text" />
                    </div>
                    <div class="col-sm-4 form-control">
                        <input placeholder="Enter Family" name="Family" class="input-group" type="text" />
                    </div>
                    <div class="col-sm-4 form-control">
                        <input placeholder="Enter Email@site.com " name="Email" class="input-group" type="email" />
                    </div>
                </div>
            </form>
            <div class="col-sm-3">
                <ajax-button ajax-controller="Home" ajax-action="Create" ajax-form-id="frmCreate" ajax-success-func="SuccessCreate"
                             class="btn btn-sm btn-success">
                    Create
                </ajax-button>
            </div>
        </div>
        
Finally, add the scripts you need to view it, check the code below

    <script>
        function SuccessCreate(data) {
            console.log(data);
            $("#tbodyPerson").append(data);
       

        }
        function SuccessDelete(data) {
            $("#tr" + data.id).fadeOut();
        }
    </script>
    <script src="~/js/AjaxHelper.js"></script>

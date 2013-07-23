<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="FAQ.aspx.vb" Inherits="Default4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

<!-- jQuery Script for toggling the answer to show or hide.-->
<script type="text/javascript">
    $(document).ready(function () {
        $("a[name^='question-']").each(function () {
            $(this).click(function () {
                if ($("#" + this.name).is(':hidden')) {
                    $("#" + this.name).slideToggle('fast');
                } else {
                    $("#" + this.name).slideToggle('fast');
                }
                return false;
            });
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<h2>Frequently Asked Questions</h2>

    To be filled out completely , once we know what questions they want.
<br />
    <!-- Ordering -->
   <h2>Ordering</h2>
   <a href="#" name="question-1">What forms of payment do we accept?</a><br />
   <div class="answer" id="question-1">We accept the following forms of payment: PayPal or Credit Card.<br /><br /></div>
   <a href="#" name="question-2">How do I order frames?</a><br />
   <div class="answer" id="question-2">Choose a frame and follow the steps.<br /><br /></div>
   <!-- Frames-->
    <h2>Frames</h2>
   <a href="#" name="question-3">Where do I get my perscription?</a><br />
   <div class="answer" id="question-3">You can get your perscription from your optometrist.<br /><br /></div>
   
   <a href="#" name="question-4">What is Mono PD?</a><br />
   <div class="answer" id="question-4">Mono PD stands for Mono Pupillary Distance. Mono Pupillary Distance is the distance from the bridge of the nose to the pupil each way.<br /><br /></div>
   
   <a href="#" name="question-9">What is DBT</a>
   <div class="answer" id="question-9">DBT stands for Distance Between Temple. It is the distance between your right and left temple which gives us a measurement to ensure that the frame is not to tight or not to loose.<br /><br /></div>
   <a href="#" name="question-5">How do I get the best fit frames for my face?</a><br />
   <div class="answer" id="question-5">You can measure your face by going to our <a href="measure.aspx">measuring page</a> to get the dimensions.<br/> These
   dimensions can now be used to find the best fit frames.<br /><br /></div>     
  
   <!-- Helpful Information-->
    <h2>Helpful Information</h2>
   <a href="#" name="question-6">Where is the glossary of terms?</a><br />
   <div class="answer" id="question-6">The glossary can be found <a href="glossary.aspx">here</a><br /><br /></div>
   
   <!-- Contact Information -->
   <h2>Contact Information</h2>
   <a href="#" name="question-7">How can I contact On-Site Eyewear?</a><br />
   <div class="answer" id="question-7">You can contact us by ...<br /><br /></div>
   
   <!-- Contact Lens -->
   <h2>Contact Lenses</h2>
   <a href="#" name="question-8">When should i replace my contact lenses?</a><br />    
   <div class="answer" id="question-8">It is advisable not to wear contact lenses past the recommended replacement schedule.<br /> Following the recommended replacement schedule ensures a fresh and comfortable pair is worn.<br /><br /></div>         
</asp:Content>


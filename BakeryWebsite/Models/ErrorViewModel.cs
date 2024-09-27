using System;

namespace BakeryWebsite.Models
{
    /**
     *
     * @author Roshan Phakami PunMagar
     * 
     * File Name: ErrorViewModel.cs
     * Date: 27/09/2024
     * Purpose: Represents the error model used to display error 
     *          information in the application.
     *
     * ******************************************************
     */
    public class ErrorViewModel
    {
        // The unique identifier for the request, used for tracking and logging purposes.
        public string RequestId { get; set; }

        // A read-only property that indicates whether the RequestId is available.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

provider "google" {
  project = "GCP-4-Dev"
  region = "us-central1"
}
terraform {
  backend "gcs" {
    bucket = "necobucket_terraformstate"
    prefix = "terraform/state"
  }
    
  required_providers {
    google = {
      source = "hashicorp/google"
      version = "~> 5.33.0"
    }
  }
}
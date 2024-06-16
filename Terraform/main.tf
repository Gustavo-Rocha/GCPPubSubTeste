resource "google_pubsub_topic" "teste_topic" {
  name = "teste_topic_tf"
  project = "gcp-4-dev-417723"
  labels = {
    foo = "teste_topic"
  }
  message_retention_duration = "86600s"
}

resource "google_pubsub_subscription" "teste_subscription" {
  name = "teste_subscription_tf"
  project = "gcp-4-dev-417723"
  topic = google_pubsub_topic.teste_topic.name
  message_retention_duration = "1200s"
  retain_acked_messages = true

  ack_deadline_seconds = 20
}

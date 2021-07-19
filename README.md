# Getting Started.
## Prerequisites
Install Docker and Docker Compose: https://www.docker.com/products/docker-desktop

## RabbitMQ
1. Start up RabbitMQ by running: docker-compose up -d rabbitmq in the downloaded repository
2. Head to http://127.0.0.1:15672/
3. Under the Admin section add a virtual host called prod.

## Consumer Project
1. Run the Consumer app by opening a new terminal: docker-compose up consumer
2. Arguments for the RabbitMQ Uri are set under the appsettings.json of the consumer application.

## Producer Project
1. Run the Producer application and send messages to the queue.
2. Arguments for the RabbitMQ Uri are set under the appsettings.json of the producer application.

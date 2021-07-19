# Getting Started.

## RabbitMQ
1. Start up RabbitMQ.
2. Head to http://127.0.0.1:15672/
3. Under the Admin section add a virtual host.

## Consumer Project
1. Download the the Consumer docker image: docker pull ryanfouche/projects:consumer
2. Run the docker Image.
3. Enter "docker logs" in the same command window to view output from the consumer app.
4. Arguments for the RabbitMQ Uri are set under Consumer Project -> Properties -> Debug -> Application Arguments. Defualts are "guest guest 127.0.0.1 5672 prod".

## Producer Project
1. Run the Producer application and send messages to the queue.
2. Arguments for the RabbitMQ Uri are set under Producer Project -> Properties -> Debug -> Application Arguments. Defualts are "guest guest 127.0.0.1 5672 prod".

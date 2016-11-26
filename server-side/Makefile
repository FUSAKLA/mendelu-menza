
REPOSITORY=fusakla/
IMAGE_NAME=mendelu-menza
VERSION=0.0.8

BUILD_NAME=$(REPOSITORY)$(IMAGE_NAME):$(VERSION)

docker-build:
	docker build -t $(BUILD_NAME) .

docker-push:
	docker push $(BUILD_NAME) 

docker-run:
	docker run -it -p 5000:5000 $(BUILD_NAME) bash

docker-run-daemon:
	docker run -d $(BUILD_NAME)

run:
	python3 ./src/mendelu-menza.py


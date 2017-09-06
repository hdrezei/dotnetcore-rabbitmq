#!/bin/bash
docker run nyom.workflow.manager --alias=4063debe-6ea0-4c54-b36e-2c65d0d6d060  --net net.workflow --links mssql.workflow:nyom.workflow.manager -e CAMPANHA=4063debe-6ea0-4c54-b36e-2c65d0d6d060 -v tcp://docker.for.win.localhost:2375:/var/run/docker.sock

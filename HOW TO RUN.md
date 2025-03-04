Get a Mongo DB, Mongo Express and GT Motive Estimate API ready by running:
```
docker compose -f 'docker-compose.yml' up -d --build
```

For debugging API but running DB:
```
docker compose -f 'docker-compose.yml' up -d --build 'gtmotive_estimate_local_db'
```

You can access mongo-express via http://localhost:8081/
GTMotive API via http://localhost:80
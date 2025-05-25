FROM postgres:latest

# copy the initialization script
COPY ./scripts/create-tables-if-not-exists.sql /docker-entrypoint-initdb.d/

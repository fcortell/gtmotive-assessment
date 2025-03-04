FROM mongo
WORKDIR /jsondata
COPY vehicles.json /jsondata/vehicles.json
COPY rentals.json /jsondata/rentals.json
COPY seed.sh /jsondata/seed.sh
CMD ["/jsondata/seed.sh"]
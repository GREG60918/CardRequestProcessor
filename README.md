* Please find a postman with example requests in the repository folder
* I've used a connection string for my local machine, please update as necessary - in reality this would be an environment variable

Extra thing's I'd include/consider in an enterprise level project:

* integration level testing - testing the endpoint and db
* sync/async - make the db calls async etc. if required
* In reality I think this task would suit multiple endpoints - 1 for getting the applicant from an applicant db and the the post request to the cardrequests endpoint, giving only the id in the request body

If you have any questions please just let me know
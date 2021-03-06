[![Build Status](https://travis-ci.org/btimby/cloudstrype-array.svg?branch=master)](https://travis-ci.org/btimby/cloudstrype-array)
[![Coverage Status](https://coveralls.io/repos/github/btimby/cloudstrype-array/badge.svg?branch=master)](https://coveralls.io/github/btimby/cloudstrype-array?branch=master)

Cloudstrype.io
==============

**Personal multi-cloud storage.**

Cloudstrype allows you to add many free (or paid) storage clouds to your account.
Once added the clouds are used together for form one large storage cloud that you
can access via Cloudstrype. The files are chunked, encrypted and striped across
your cloud accounts. You can choose the replica level (or RAID) to ensure
availability when one of the clouds is offline.

Cloudstrype provides an API for accessing your files. The API utilizes OAuth for
authentication, meaning that you can integrate your applications with Cloudstrype.

Array Client
============

This is the array client, a multi-platform C# client that makes PC harddrive space
available within your cloudstrype.io cloud storage account.

Now you can augment your free cloud storage with unused space from any computer
you are able to run the Cloudstrype Array Client on!

Open Source
-----------

Development of the Cloudstrype application is completely open. If there is a
feature you desire, you can submit a pull request to this repository or pay someone
to do it for you (or maybe just ask nicely). Continuous integration means that as
soon as your changes are approved and pass tests, the code will be "deployed" and
available to everyone at https://cloudstrype.io/.

A lot of Open Source software and free services go into providing Cloudstrype free
of charge. Below is a list of great projects you should check out.

- Travis CI
- Coveralls
- Github
- Sentry.io
- Python
- PostgreSQL
- Django
- Linux
- Letsencrypt
- Nginx
- Memcached
- Supervisord
- UWSGI
- djangorestframework
- django-environ
- django-mailjet
- django-filter
- django-extensions
- django-rest-auth
- django-oauth-toolkit
- oauthlib
- requests
- requests_oauthlib
- psycopg2
- hashids
- python-uptimerobot
- Mailjet
- UptimeRobot

Development
-----------

This agent is written using MonoDevelop on Linux, but should work on other
platforms. A number of nuget packages are utilized.

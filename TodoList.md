# TODO List

- ❌ Refactor project

- ✅ ~~GZIP COMPRESSION~~
- ✅ ~~HEALTHECHECKS~~
- ✅ ~~CORS~~
- ❌ API AUTHENTICATION AND AUTHORIZATION
- ❌ HATEOAS
- ❌ DATABASE

## Emoji References
- ✅ Done / ❌ To do / 👷 WIP / ⛔ Will not be implemented
- <span class="verb get">GET</span> 
<span class="verb post">POST</span> 
<span class="verb put">PUT</span>
<span class="verb delete">DELETE</span>

- <span class="verb patch">PATCH</span>
<span class="verb head">HEAD</span>
<span class="verb options">OPTIONS</span>
<span class="verb trace">TRACE</span>

## Implement routes and necesary responses for all Models
- We need more models?: ❌ User, ❌ Skill, ✅ Goal, ✅ Category
    - ❌ User
        - <span class="verb get">GET</span> users
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb get">GET</span> user
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb post">POST</span> user
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb put">PUT</span> user
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb delete">DELETE</span> user
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb options">OPTIONS</span> user
            - ❌ 200 OK
        - ❌ <span class="verb head">HEAD</span> user
            - ❌ 200 OK
            
    - ❌ Skill
        - ❌ <span class="verb get">GET</span> skills
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb get">GET</span> skill
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb post">POST</span> skill
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb put">PUT</span> skill
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb delete">DELETE</span> skill
            - ❌ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ❌ <span class="verb options">OPTIONS</span> user
            - ❌ 200 OK
        - ❌ <span class="verb head">HEAD</span> user
            - ❌ 200 OK
    
    - 👷 Goal
        - 👷 <span class="verb get">GET</span> /goals
            - ✅ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - 👷 <span class="verb get">GET</span> /goal/goalId
            - ✅ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - 👷 <span class="verb post">POST</span> /goal
            - ❌ 200 OK
            - ✅ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - 👷 <span class="verb put">PUT</span> /goal/goalId
            - ✅ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - 👷 <span class="verb delete">DELETE</span> goal/goalId
            - ✅ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ✅ <span class="verb options">OPTIONS</span> user
            - ✅  200 OK
        - ✅ <span class="verb head">HEAD</span> user
            - ✅ 200 OK
                        
    - 👷 Category
        - 👷 <span class="verb get">GET</span> /categories
            - ✅ 200 OK
            - ❌ 201 Create
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - 👷 <span class="verb get">GET</span> /category/categoryId
            - ✅ 200 OK
            - ❌ 201 Create
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - 👷 <span class="verb post">POST</span> category
            - ❌ 200 OK
            - ✅ 201 Create
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - 👷 <span class="verb put">PUT</span> category/categoryId
            - ✅ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - 👷 <span class="verb delete">DELETE</span> category/categoryId
            - ✅ 200 OK
            - ❌ 201 Created
            - ❌ 204 No Content
            - ❌ 400 Bad Req
            - ❌ 401 Unauthorized (unauthenticated)
            - ❌ 403 Forbiden (unauthorized)
            - ❌ 404 Not Found
            - ❌ 405 Method Not Allowed
            - ❌ 418 I'm a teapot
            - ❌ 422  Unprocessable Entity
            - ❌ 500 Internal Server Error
            - ❌ Validations?
            - ❌ HATEOAS
        - ✅  <span class="verb options">OPTIONS</span> user
            - ✅  200 OK
        - ✅ <span class="verb head">HEAD</span> user
            - ✅ 200 OK

### Related
- [Status codes: MozzilaDoc](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status)
- [Status codes: RestApiTutorial](https://www.restapitutorial.com/httpstatuscodes.html)


<style>
.get{
    background:#61affe;
}
.post{
    background:#49cc90;
}
.put{
    background:#fca130;
}
.delete{
    background:#f93e3e;
}
.options{
    background:#0d5aa7;
}
.patch{
    background:#50e3c2;
}
.head{
    background:#9012fe;
}
.trace{
    background:#000;
}
.verb {
  border-radius: 3px;
  color: #fff;
  font-family: sans-serif;
  font-size: 14px;
  font-weight: 700;
  min-width: 80px;
  padding: 6px;
  text-align: center;
  text-shadow: 0 1px 0 rgba(0,0,0,.1);
  margin: 5px;
 }

</style>
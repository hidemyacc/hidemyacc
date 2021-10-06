<a name="top"></a>

# Hidemyacc 2.0.56+ APIs v1.0.0

# Table of contents

- [Profiles](#Profiles)
  - [1. Danh sách profiles](#1.-Danh-sách-profiles)
  - [2. Tạo profiles](#2.-Tạo-profiles)
  - [3. Start Profile](#3.-Start-Profile)
  - [4. Stop Profile](#4.-Stop-Profile)
  - [5. Delete Profile](#5.-Delete-Profile)
- [User](#User)
  - [1. Truy vấn thông tin tài khoản](#1.-Truy-vấn-thông-tin-tài-khoản)

---

# <a name='Profiles'></a> Profiles

## <a name='1.-Danh-sách-profiles'></a> 1. Danh sách profiles

[Back to top](#top)

<p>Lấy về danh sách profiles của người dùng.</p>

```
GET http://127.0.0.1:12368/profiles
```

### Examples

Curl example

```bash
curl http://127.0.0.1:12368/profiles
```

Javascript example

```js
const hidemyacc = new Hidemyacc();
const user = await hidemyacc.profiles();
```

### Success response

#### Success response - `Success 200`

| Name | Type       | Description                   |
| ---- | ---------- | ----------------------------- |
| data | `Object[]` | <p>profiles List of user.</p> |

### Success response example

#### Success response example - `Success-Example`

```json
    HTTP/1.1 200 OK
 {
    "code": 1,
    "data":
    [
        {
            "id": "615d0c642a151505fe6a3a1a",
            "name": "Eleanore Paysinger",
            "notes": "",
            "browserType": "chrome",
            "os": "mac",
            "platform": "MacIntel",
            "proxy":
            {
                "autoProxyPassword": "",
                "autoProxyRegion": "us",
                "autoProxyServer": "",
                "autoProxyUsername": "",
                "host": "",
                "mode": "none",
                "password": "",
                "port": null,
                "proxyEnabled": false,
                "torProxyRegion": "us",
                "username": ""
            },
            "role": "owner",
            "createdAt": "2021-10-06T02:39:32.840Z",
            "updatedAt": "2021-10-06T03:10:10.060Z"
        },
        {
            "id": "615d066a2a151505fe6a24ad",
            "name": "Antonetta Blan",
            "notes": "",
            "browserType": "chrome",
            "os": "mac",
            "platform": "MacIntel",
            "proxy":
            {
                "autoProxyPassword": "",
                "autoProxyRegion": "us",
                "autoProxyServer": "",
                "autoProxyUsername": "",
                "host": "",
                "mode": "none",
                "password": "",
                "port": null,
                "proxyEnabled": false,
                "torProxyRegion": "us",
                "username": ""
            },
            "role": "owner",
            "createdAt": "2021-10-06T02:14:02.691Z",
            "updatedAt": "2021-10-06T02:14:02.691Z"
        }
    ]
}
```

### Error response

#### Error response - `Error 4xx`

| Name | Type | Description                         |
| ---- | ---- | ----------------------------------- |
| 401  |      | <p>Chưa đăng nhập vào tài khoản</p> |

### Error response example

#### Error response example - `Response (example):`

```json
HTTP/1.1 401 Not Authenticated
{
  "code": 0,
  "message": "Unauthorized",
  "data": {}
}
```

## <a name='2.-Tạo-profiles'></a> 2. Tạo profiles

[Back to top](#top)

<p>Tạo profile.</p>

```
POST http://127.0.0.1:12368/profiles
```

### Parameters - `Parameter`

| Name    | Type     | Description                                                                                                                                                                                                                                                                  |
| ------- | -------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| os      | `String` | <p>Hệ điều hành. Danh sách các hệ điều hành hỗ trợ: (win, mac, lin, android, ios)</p>                                                                                                                                                                                        |
| name    | `String` | <p>Optional Tên profile</p>                                                                                                                                                                                                                                                  |
| notes   | `String` | <p>Optional Chú thích</p>                                                                                                                                                                                                                                                    |
| browser | `String` | <p>Optional Trình duyệt. Danh sách trình duyệt hỗ trợ: (chrome, opera, edge, firefox)</p>                                                                                                                                                                                    |
| proxy   | `String` | <p>Optional Proxy. Sử dụng theo định dạng sau: &quot;{&quot;host&quot;:&quot;103.171.112.245&quot;,&quot;mode&quot;:&quot;http&quot;,&quot;password&quot;:&quot;1ee93edba5c911c33&quot;,&quot;port&quot;:19099,&quot;username&quot;:&quot;nguyenmanhtien.bh&quot;}&quot;</p> |

### Examples

Curl example

```bash
curl -X POST http://127.0.0.1:12368/profiles -i -d "os=mac&name=test&notes=example&browser=chrome"
```

Javascript example

```js
const hidemyacc = new Hidemyacc();
const proxy = {
  host: "103.171.112.245",
  mode: "http",
  password: "1ee93edba5c911c33",
  port: 19099,
  username: "nguyenmanhtien.bh",
};
const user = await hidemyacc.create(os, name, notes, browser, proxy);
```

### Success response

#### Success response - `Success 200`

| Name | Type     | Description                        |
| ---- | -------- | ---------------------------------- |
| data | `Object` | <p>Thông tin profile được tạo.</p> |

### Success response example

#### Success response example - `Success-Example`

```json

HTTP/1.1 200 OK
    {
        "code": 1,
        "data":
        {
            "browserType": "chrome",
            "createdAt": "2021-10-06T09:28:43.178Z",
            "id": "615d6c4b2a151505fe6ba060",
            "name": "test",
            "notes": "example",
            "os": "mac",
            "platform": "MacIntel",
            "proxy":
            {
                "autoProxyPassword": "",
                "autoProxyRegion": "us",
                "autoProxyServer": "",
                "autoProxyUsername": "",
                "host": "",
                "mode": "none",
                "password": "",
                "port": 80,
                "proxyEnabled": false,
                "torProxyRegion": "us",
                "username": ""
            },
            "role": "owner",
            "updatedAt": "2021-10-06T09:28:43.178Z"
        }
    }
```

### Error response

#### Error response - `Error 4xx`

| Name | Type | Description                         |
| ---- | ---- | ----------------------------------- |
| 401  |      | <p>Chưa đăng nhập vào tài khoản</p> |

### Error response example

#### Error response example - `Response (example):`

```json
HTTP/1.1 401 Not Authenticated
{
  "code": 0,
  "message": "Unauthorized",
  "data": {}
}
```

## <a name='3.-Start-Profile'></a> 3. Start Profile

[Back to top](#top)

<p>Mở profile.</p>

```
POST http://127.0.0.1:12368/profiles/start/:id
```

### Examples

Curl example

```bash
curl -X POST http://127.0.0.1:12368/profiles/start/615d6c4b2a151505fe6ba060
```

Javascript example

```js
const hidemyacc = new Hidemyacc();
const user = await hidemyacc.start("615d6c4b2a151505fe6ba060");
```

### Success response

#### Success response - `Success 200`

| Name  | Type     | Description                            |
| ----- | -------- | -------------------------------------- |
| port  | `Number` | <p>PORT auto</p>                       |
| wsUrl | `String` | <p>Được dùng để tích hợp Puppeteer</p> |

### Success response example

#### Success response example - `Success-Example`

```json

HTTP/1.1 200 OK
    {
    "code": 1,
    "data": {
            "port": 22881,
            "wsUrl": "ws://127.0.0.1:22881/devtools/browser/bb79645f-eb15-441e-811d-c38b36a13111"
        }
    }
```

### Error response

#### Error response - `Error 4xx`

| Name | Type | Description                         |
| ---- | ---- | ----------------------------------- |
| 401  |      | <p>Chưa đăng nhập vào tài khoản</p> |

### Error response example

#### Error response example - `Response (example):`

```json
HTTP/1.1 401 Not Authenticated
{
  "code": 0,
  "message": "Unauthorized",
  "data": {}
}
```

## <a name='4.-Stop-Profile'></a> 4. Stop Profile

[Back to top](#top)

<p>Mở profile.</p>

```
POST http://127.0.0.1:12368/profiles/stop/:id
```

### Examples

Curl example

```bash
curl -X POST http://127.0.0.1:12368/profiles/stop/615d6c4b2a151505fe6ba060
```

Javascript example

```js
const hidemyacc = new Hidemyacc();
const user = await hidemyacc.stop("615d6c4b2a151505fe6ba060");
```

### Success response

#### Success response - `Success 200`

| Name  | Type     | Description                            |
| ----- | -------- | -------------------------------------- |
| port  | `Number` | <p>PORT auto</p>                       |
| wsUrl | `String` | <p>Được dùng để tích hợp Puppeteer</p> |

### Success response example

#### Success response example - `Success-Example`

```json

HTTP/1.1 200 OK
    {
        "code": 1
    }
```

### Error response

#### Error response - `Error 4xx`

| Name | Type | Description                         |
| ---- | ---- | ----------------------------------- |
| 401  |      | <p>Chưa đăng nhập vào tài khoản</p> |

### Error response example

#### Error response example - `Response (example):`

```json
HTTP/1.1 401 Not Authenticated
{
  "code": 0,
  "message": "Unauthorized",
  "data": {}
}
```

## <a name='5.-Delete-Profile'></a> 5. Delete Profile

[Back to top](#top)

<p>Xóa profile.</p>

```
POST http://127.0.0.1:12368/profiles/delete/:id
```

### Examples

Curl example

```bash
curl -X POST http://127.0.0.1:12368/profiles/delete/615d6c4b2a151505fe6ba060
```

Javascript example

```js
const hidemyacc = new Hidemyacc();
const user = await hidemyacc.delete("615d6c4b2a151505fe6ba060");
```

### Success response example

#### Success response example - `Success-Example`

```json

HTTP/1.1 200 OK
    {
        "code": 1
    }
```

### Error response

#### Error response - `Error 4xx`

| Name | Type | Description                         |
| ---- | ---- | ----------------------------------- |
| 401  |      | <p>Chưa đăng nhập vào tài khoản</p> |

### Error response example

#### Error response example - `Response (example):`

```json
HTTP/1.1 401 Not Authenticated
{
  "code": 0,
  "message": "Unauthorized",
  "data": {}
}
```

# <a name='User'></a> User

## <a name='1.-Truy-vấn-thông-tin-tài-khoản'></a> 1. Truy vấn thông tin tài khoản

[Back to top](#top)

<p>Truy vấn thông tin tài khoản.</p>

```
GET http://127.0.0.1:12368/me
```

### Examples

Curl example

```bash
curl http://127.0.0.1:12368/me
```

Javascript example

```js
const hidemyacc = new Hidemyacc();
const user = await hidemyacc.me();
```

### Success response

#### Success response - `Success 200`

| Name                  | Type      | Description                                         |
| --------------------- | --------- | --------------------------------------------------- |
| data                  | `Object`  | <p>Thông tin user</p>                               |
| data.affiliate        | `Number`  | <p>Tỷ lệ % dành cho đối tác tham gia affiliate</p>  |
| data.createdAt        | `Date`    | <p>Ngày tạo tài khoản</p>                           |
| data.email            | `email`   | <p>Địa chỉ email</p>                                |
| data.expireDate       | `Date`    | <p>Ngày hết hạn</p>                                 |
| data.id               | `String`  | <p>Id tài khoản</p>                                 |
| data.lockEnabled      | `Boolean` | <p>Tài khoản có bị khóa hay không?</p>              |
| data.plan             | `Object`  | <p>Thông tin gói đăng ký mà tài khoản đang dùng</p> |
| data.profiles         | `Number`  | <p>Số lượng profile hiện tại của người dùng</p>     |
| data.plan.maxProfiles | `Number`  | <p>Số lượng profile mà gói hỗ trợ</p>               |
| data.plan.name        | `Number`  | <p>Tên gói</p>                                      |

### Success response example

#### Success response example - `Success-Example`

```json
HTTP/1.1 200 OK
{
    "code": 1,
    "data":
    {
        "affiliate": 10,
        "createdAt": "2021-03-11T10:47:58.666Z",
        "email": "test@hidemyacc.com",
        "expireDate": "2022-11-03T07:24:58.408Z",
        "id": "613c895e92097a1b0ea30b7b",
        "lockEnabled": false,
        "plan":
        {
            "maxProfiles": 1000,
            "name": "Business"
        },
        "profiles": 25
    }
}
```

### Error response

#### Error response - `Error 4xx`

| Name | Type | Description                         |
| ---- | ---- | ----------------------------------- |
| 401  |      | <p>Chưa đăng nhập vào tài khoản</p> |

### Error response example

#### Error response example - `Response (example):`

```json
HTTP/1.1 401 Not Authenticated
{
  "code": 0,
  "message": "Unauthorized",
  "data": {}
}
```

# User Management

| Functionality            | API Endpoint                              | Role Required   |
| ------------------------ | ----------------------------------------- | --------------- |
| Create User              | `POST /api/users`                         | `administrator` |
| Add Child to Parent      | `POST /api/users/children/register`       | `parent`        |
| Update User              | `PUT /api/users/{userId}`                 | `administrator` |
| Update Own Profile       | `PUT /api/users/profile`                  | `authenticated` |
| Change Password          | `POST /api/users/change-password`         | `authenticated` |
| Activate/Deactivate User | `POST /api/users/{userId}/(de)activate`   | `administrator` |
| Delete User              | `DELETE /api/users/{userId}`              | `administrator` |
| Reset Password           | `POST /api/users/{userId}/reset-password` | `administrator` |
| Get Users (Filtered)     | `GET /api/users`                          | `administrator` |
| Get User By ID           | `GET /api/users/{userId}`                 | `administrator` |
| Get User By Email        | `GET /api/users/by-email?email=`          | `administrator` |
| Get User By Username     | `GET /api/users/by-username?username=`    | `administrator` |
| Get Users (Paginated)    | `GET /api/users/paged`                    | `administrator` |

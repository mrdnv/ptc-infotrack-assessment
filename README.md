# SettlementBookingTest
## Technical notes
- .NET 5
- Clean Architecture
- Domain-drivent design
- Mediator pattern using MediatR
- Unit Tests using XUnit

## Swagger
https://localhost:44355/swagger

## How to execute


1. Create an Appointment
```
curl --request POST \
  --url https://localhost:44355/Booking
  --header 'Content-Type: application/json
  --data '{
	"bookingTime": "09:30",
	"name": "John"
}'
```

2. Query all appointments
```
curl --request GET\
  --url https://localhost:44355/Booking
  --header 'Content-Type: application/json
```
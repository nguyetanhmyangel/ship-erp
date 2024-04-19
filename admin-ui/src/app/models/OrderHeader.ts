    export class OrderHeader {
        OrderID?: BigInt
        OrderTypID?: BigInt
        ClientID?: BigInt
        VesselID?: BigInt
        RegistrationValidity?: string
        RepairStartDate?: Date
        RepairEndDate?: Date
        TotalDuration?: Date
        MaterialOrderDeadline?: Date
        ServiceOrderDeadline?: Date
        ApprovedBudget?: Number
    }
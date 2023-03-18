import { ContainerInDepot } from "./container"

export type Depot = {
    id: number,
    name: string,
    location: string,
    owener: string
}

export type DepotExtraInfo = {
    containers: ContainerInDepot[]
}

export type DepotFullInfo = Depot & DepotExtraInfo;

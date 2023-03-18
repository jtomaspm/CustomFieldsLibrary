export type Container = {
    id : number,
    code : string,
    containerType : string,
    owner : string,
    depot : string,
}

export type ContainerInDepot = Container & { inDate : string }


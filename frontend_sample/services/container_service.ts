import { Container } from "@/types/container";
import { Operation } from "@/types/operation";
import { getTableFormat } from "@/utils/date_formater";
import axios from "axios";
import { getAxiosConfigs, getBackendApiEndpoint } from "./backend_service";

export async function getContainers() {
    const res = await axios.get(getBackendApiEndpoint() + 'Container', getAxiosConfigs()).catch((error) => {
        console.log(error);
    });
    return res?.data as Container[];
}

export async function getContainerFullDetails(id: number) {
    const res = await axios.get(getBackendApiEndpoint() + 'Container/' + id, getAxiosConfigs()).catch((error) => {
        console.log(error);
    });
    let result = res?.data as Container & {operations : Operation[]};
    if (result != undefined && result.operations != undefined) {
        result.operations = result.operations.map((operation) => {
            return {
                client : operation.client,
                container : operation.container,
                date : getTableFormat(operation.date),
                depot : operation.depot,
                id : operation.id,
                operationType : operation.operationType,
                supplier : operation.supplier
            } as Operation   
        });
    }
    return result as Container & {operations : Operation[]};
}


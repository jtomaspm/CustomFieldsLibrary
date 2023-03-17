import https from 'https';

export function getAxiosConfigs() {
    const agent = new https.Agent({
            rejectUnauthorized : false
        });
    return {
        httpsAgent: agent
    };
} 

export function getBackendApiEndpoint() {
    return 'https://localhost:7037/api/'
}
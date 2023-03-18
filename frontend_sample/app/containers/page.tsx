import { ContainerInDepot, getContainers } from "@/services/container_service";

export default async function ContainersPage() {
  const th_class = "text-1xl";
  const containers = await getContainers();
  return (
    <div>
      <h1 className="text-center text-4xl text-blue-500 m-5">Containers</h1>
      <div className="overflow-x-auto">
        <table className="table table-compact p-0">
          <thead>
            <tr>
              <th>
                <h1 className={th_class}>Code</h1>
              </th>
              <th>
                <h1 className={th_class}>Type</h1>
              </th>
              <th>
                <h1 className={th_class}>Owner</h1>
              </th>
              <th>
                <h1 className={th_class}>In Depot</h1>
              </th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            { containers.map((container) => {
              const tr_class = "hover:bg-cyan-900";
              const info_href = "/containers/" + container.id;
              return (
                <tr className={tr_class} key={container.id}>
                  <td>{container.code}</td>
                  <td>{container.containerType}</td>
                  <td>{container.owner}</td>
                  <td>{container.depot}</td>
                  <td>
                    {container.depot !== "" && (
                      <button className="rounded-full btn btn-outline btn-error btn-xs mx-1">
                        Out
                      </button>
                    )}
                    <a
                      href={info_href}
                      className="rounded-full btn btn-outline btn-accent btn-xs mx-1"
                    >
                      Info
                    </a>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
      </div>
    </div>
  );
}


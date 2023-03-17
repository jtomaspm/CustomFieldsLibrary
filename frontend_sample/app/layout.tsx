/* eslint-disable @next/next/no-head-element */

export const dynamic = 'auto',
    dynamicParams = true,
    revalidate = 0,
    fetchCache = 'auto',
    runtime = 'nodejs',
    preferedRegion = 'auto'


import Link from "next/link";
import './global.css'

export default function RootLayout({
    children,
}: {
    children: React.ReactNode;
}) {
    return (
        <html>
            <head></head>
            <body>
                <main>
                    <nav>
                        <Link href="/">Home</Link>
                        <Link href="/depots">Depots</Link>
                    </nav>

                    {children}
                </main>
            </body>
        </html>
    );
}

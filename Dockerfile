FROM microsoft/dotnet:2.1-sdk-alpine as builder

# Setup Working directory
RUN mkdir /usr/src \
    && mkdir /usr/src/app \
    && apk add --no-cache nodejs nodejs-npm

# Switch to the Workdir
WORKDIR /usr/src/app

COPY . . 
RUN dotnet restore \
    && dotnet add package Microsoft.ApplicationInsights.AspNetCore --version 2.1.1 \
    && npm install

# Now Build the c-sharp application
RUN dotnet publish -o DotNetVueBlog

# Now start the Docker Container wanted only with the runtime
FROM microsoft/dotnet:2.1-runtime-alpine

RUN apk add --no-cache libuv \
    && ln -s /usr/lib/libuv.so.1 /usr/lib/libuv.so \
    && mkdir /usr/src \
    && mkdir /usr/src/app 

WORKDIR /usr/src/app

COPY --from=builder /usr/src/app .

EXPOSE 5000

CMD ["dotnet", "./DotNetVueBlog/DotNetVueBlog.dll"]


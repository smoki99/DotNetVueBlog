FROM microsoft/dotnet:2.1-sdk-alpine as builder

# Setup Working directory
RUN mkdir /usr/src \
    && mkdir /usr/src/app \
    && apk add --no-cache nodejs nodejs-npm

# Switch to the Workdir
WORKDIR /usr/src/app

# Copy only the DotnetVueBlog.csproj since it contains all needed dotnet packages
COPY DotNetVueBlog.csproj .
RUN dotnet restore ./DotNetVueBlog.csproj

# Copy only package.json for npm install since it contains all needed node packages
COPY package.json npm-shrinkwrap.json .
RUN npm install

# Now Build the c-sharp application
COPY . . 
RUN dotnet publish -o DotNetVueBlog

# Now start the Docker Container wanted only with the runtime
FROM microsoft/dotnet:2.1-2.1-runtime-alpine

# Install Nodejs
RUN apk add --no-cache nodejs libuv \
    && ln -s /usr/lib/libuv.so.1 /usr/lib/libuv.so \
    && mkdir /usr/src \
    && mkdir /usr/src/app \
    && mkdir /usr/src/app/node_modules

WORKDIR /usr/src/app

# Copy Only C# Build to local
COPY --from=builder /usr/src/app/DotnetVueBlog .

# Copy only node_modules local
COPY --from=builder /usr/src/app/DotnetVueBlog/node_modules ./node_modules

EXPOSE 5000

CMD ["dotnet", "./DotNetVueBlog.dll"]


#!groovy
pipeline {
    agent {
        docker {
            image 'nosinovacao/dotnet-sonar:20.07.0'
        }
    }
    environment {
        HOME = '/tmp'
    } 
    stages {
        stage('Preparation') {
            steps {
                checkout scm
            }
        }
        stage('Build') {
            steps {
                sh """
                #!/bin/bash
                dotnet build FirstSolution.sln
                """
            }
        }
        stage('Test') {
            steps {
                sh """
                #!/bin/bash
                dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
                """
            }
        }
        stage('Sonar') {
            steps {
                sh """
                #!/bin/bash
                dotnet build-server shutdown
                dotnet sonarscanner begin /k:"FirstCoreProject" /d:sonar.host.url=http://localhost:9000 /d:sonar.cs.opencover.reportsPaths="FirstCoreProject/coverage.opencover.xml" /d:sonar.coverage.exclusions="FirstCoreProject/Test1.cs"
                dotnet build FirstSolution.sln
                dotnet sonarscanner end
                """
            }
        }
        stage('Run') {
            steps {
                sh """
                #!/bin/bash
                cd FirstCoreProject
                dotnet run
                """
            }
        }
    }
}